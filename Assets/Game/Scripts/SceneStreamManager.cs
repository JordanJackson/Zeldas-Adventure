using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneStreamManager : Singleton<SceneStreamManager>
{
    public int neighbourLoadDepth = 1;

    string currentSceneName;

    // currently loaded scene names
    HashSet<string> loadedScenes = new HashSet<string>();
    HashSet<string> loadingScenes = new HashSet<string>();
    HashSet<string> nearScenes = new HashSet<string>();

    [System.Serializable]
    public class StringEvent : UnityEvent<string> { }
    [System.Serializable]
    public class StringAsyncEvent : UnityEvent<string, AsyncOperation> { }

    public StringAsyncEvent onLoading = new StringAsyncEvent();

    public StringEvent onLoaded = new StringEvent();

    delegate void LoadHandler(string sceneName, int depth);

    void Awake()
    {
        Object.DontDestroyOnLoad(this.gameObject);
    }

    public void SetCurrent(string sceneName)
    {
        if (string.Equals(sceneName, currentSceneName)) return;
        StartCoroutine(LoadCurrentScene(sceneName));
    }

    // sets the current scene and loads it
    public void UpdateCurrentScene(string sceneName)
    {
        if (currentSceneName == null || currentSceneName != sceneName)
        {
            LoadCurrentScene(sceneName);
        }
    }

    IEnumerator LoadCurrentScene(string sceneName)
    {
        currentSceneName = sceneName;
        if (!IsLoaded(currentSceneName))
        {
            Load(currentSceneName);
        }
        while ((loadingScenes.Count > 0))
        {
            yield return null;
        }

        nearScenes.Clear();
        LoadNeighbours(currentSceneName, 0);

        while ((loadingScenes.Count > 0))
        {
            yield return null;
        }

        // unload scenes no longer needed
        UnloadFarScenes();
    }

    void LoadNeighbours(string sceneName, int depth)
    {
        // scene already addded? return
        if (nearScenes.Contains(sceneName))
        {
            return;
        }
        // add scene to near
        nearScenes.Add(sceneName);
        // at max depth? return
        if (depth >= neighbourLoadDepth)
        {
            return;
        }
        // get sceneRoot and its neighbouring scenes
        GameObject scene = GameObject.Find(sceneName);
        SceneNeighbours neighbours = (scene ? scene.GetComponent<SceneNeighbours>() : null);
        // if neighbours are null, build the list
        if (!neighbours) neighbours = CreateSceneNeighbours(scene);
        // if still null, return
        if (!neighbours) return;
        for (int i = 0; i < neighbours.sceneNames.Length; i++)
        {
            Load(neighbours.sceneNames[i], LoadNeighbours, depth + 1);
        }
    }

    SceneNeighbours CreateSceneNeighbours(GameObject scene)
    {
        if (!scene)
        {
            return null;
        }
        SceneNeighbours sceneNeighbours = scene.AddComponent<SceneNeighbours>();
        HashSet<string> neighbours = new HashSet<string>();
        SceneTrigger[] triggers = scene.GetComponentsInChildren<SceneTrigger>();
        foreach (SceneTrigger t in triggers)
        {
            neighbours.Add(t.nextSceneName);
        }
        sceneNeighbours.sceneNames = new string[neighbours.Count];
        neighbours.CopyTo(sceneNeighbours.sceneNames);
        return sceneNeighbours;
    }

    // returns true if scene is in loaded set
    bool IsLoaded(string sceneName)
    {
        return loadedScenes.Contains(sceneName);
    }

    // loads scene
    public void Load(string sceneName)
    {
        Load(sceneName, null, 0);
    }

    // loads scene with callback
    void Load(string sceneName, LoadHandler loadHandler, int depth)
    {
        if (IsLoaded(sceneName))
        {
            if (loadHandler != null) loadHandler(sceneName, depth);
            return;
        }
        loadingScenes.Add(sceneName);
        StartCoroutine(LoadAdditiveAsync(sceneName, loadHandler, depth));
    }

    IEnumerator LoadAdditiveAsync(string sceneName, LoadHandler loadHandler, int depth)
    {
        AsyncOperation asyncOp = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        onLoading.Invoke(sceneName, asyncOp);
        yield return asyncOp;
        FinishLoad(sceneName, loadHandler, depth);
    }

    void FinishLoad(string sceneName, LoadHandler loadHandler, int depth)
    {
        GameObject scene = GameObject.Find(sceneName);
        loadingScenes.Remove(sceneName);
        loadedScenes.Add(sceneName);
        onLoaded.Invoke(sceneName);
        if (loadHandler != null)
        {
            loadHandler(sceneName, depth);
        }
    }

    void UnloadFarScenes()
    {
        HashSet<string> far = new HashSet<string>(loadedScenes);
        far.ExceptWith(nearScenes);
        foreach (string sceneName in far)
        {
            Unload(sceneName);
        }
    }

    public void Unload(string sceneName)
    {
        Destroy(GameObject.Find(sceneName));
        loadedScenes.Remove(sceneName);
        SceneManager.UnloadSceneAsync(sceneName);
    }
    
    public static void SetCurrentScene(string sceneName)
    {
        Instance.SetCurrent(sceneName);
    }
}
