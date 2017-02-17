using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSetStart : MonoBehaviour {

    [Tooltip("Load this scene at start.")]
    public string startSceneName = "Level00";

    public void Start()
    {
        SceneStreamManager.SetCurrentScene(startSceneName);
        Destroy(this);
    }

}
