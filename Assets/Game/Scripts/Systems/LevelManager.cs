using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : Singleton<LevelManager>
{
    public string startScene;

    string nextLevelName;

    public Scene currentScene;
    public Scene previousScene;

    public bool loadLevel;

    public void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelLoaded;
        SceneManager.sceneUnloaded += OnLevelUnloaded;


    }

    public void OnLevelLoaded(Scene scene, LoadSceneMode lsm)
    {
        previousScene = currentScene;
        currentScene = scene;
        Debug.Log("Scene loaded.");
        MusicManager.Instance.PlayLevelMusic();
    }

    public void OnLevelUnloaded(Scene scene)
    {
        Debug.Log("Scene unloaded.");
    }

    public void LoadNextLevel(string nextLevelName)
    {
        SceneManager.UnloadSceneAsync(currentScene);
        SceneManager.LoadScene(nextLevelName, LoadSceneMode.Additive);
    }

    public void SetNextLevel(string levelName)
    {
        nextLevelName = levelName;
        loadLevel = true;
    }

    void Update()
    {
        if (loadLevel)
        {
            loadLevel = false;
            LoadNextLevel(nextLevelName);
        }
    }
}
