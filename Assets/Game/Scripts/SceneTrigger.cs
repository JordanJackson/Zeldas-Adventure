using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrigger : MonoBehaviour
{

    public GameObject sceneRoot;
    public string nextSceneName;

	void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            Debug.Log("Player entered");
            UpdateCurrentScene();
        }
    }

    void UpdateCurrentScene()
    {
        if (sceneRoot)
        {
            // update SceneStreaming system
            SceneStreamManager.SetCurrentScene(nextSceneName);
        }
    }
}
