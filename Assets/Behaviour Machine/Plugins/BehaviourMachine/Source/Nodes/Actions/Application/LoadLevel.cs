//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace BehaviourMachine {
    /// <summary>
    /// Loads the level by its name or index.
    /// </summary>
    [NodeInfo ( category = "Action/Application/",
                icon = "SceneAsset",
                description = "Loads the level by its name or index",
                url = "http://docs.unity3d.com/Documentation/ScriptReference/SceneManager.LoadScene.html")]
    public class LoadLevel : ActionNode {

        public enum LoadLevelType {
            LoadLevel,
            LoadLevelAdditive,
            LoadLevelAsync,
            LoadLevelAdditiveAsync
        }

        /// <summary>
        /// The name of the level to load.
        /// </summary>
        [VariableInfo(requiredField = false, nullLabel = "Use Index instead", tooltip = "The name of the level to load")]
        public StringVar levelName;

        /// <summary>
        /// The level to load.
        /// </summary>
        [VariableInfo(requiredField = false, nullLabel = "Use Name instead", tooltip = "The level to load")]
        public IntVar levelIndex;

        /// <summary>
        /// LoadLevel: destroys all objects in the current level. LoadLevelAdditive: does not destroy objects in the current level. LoadLevelAsync: destroys all objects in the current level,loads all objects in a background loading thread. LoadLevelAdditiveAsync: load level Additive and Async.
        /// </summary>
        [Tooltip("LoadLevel: destroys all objects in the current level. LoadLevelAdditive: does not destroy objects in the current level. LoadLevelAsync: destroys all objects in the current level,loads all objects in a background loading thread. LoadLevelAdditiveAsync: load level Additive and Async")]
        public LoadLevelType loadLevelType = LoadLevelType.LoadLevel;

        public override void Reset () {
            levelName = new ConcreteStringVar();
            levelIndex = new ConcreteIntVar();
            loadLevelType = LoadLevelType.LoadLevel;
        }

        public override Status Update () {

            if (!levelName.isNone) {
                switch (loadLevelType) {
                    case LoadLevelType.LoadLevel:
                        SceneManager.LoadScene(levelName.Value, LoadSceneMode.Single);
                        break;
                    case LoadLevelType.LoadLevelAdditive:
                        SceneManager.LoadScene(levelName.Value, LoadSceneMode.Additive);
                        break;
                    case LoadLevelType.LoadLevelAsync:
                        SceneManager.LoadSceneAsync(levelName.Value, LoadSceneMode.Single);
                        break;
                    case LoadLevelType.LoadLevelAdditiveAsync:
                        SceneManager.LoadSceneAsync(levelName.Value, LoadSceneMode.Additive);
                        break;
                }
            }
            else if (!levelIndex.isNone) {
                switch (loadLevelType) {
                    case LoadLevelType.LoadLevel:
                        SceneManager.LoadScene(levelIndex.Value, LoadSceneMode.Single);
                        break;
                    case LoadLevelType.LoadLevelAdditive:
                        SceneManager.LoadScene(levelIndex.Value, LoadSceneMode.Additive);
                        break;
                    case LoadLevelType.LoadLevelAsync:
                        SceneManager.LoadSceneAsync(levelIndex.Value, LoadSceneMode.Single);
                        break;
                    case LoadLevelType.LoadLevelAdditiveAsync:
                        SceneManager.LoadSceneAsync(levelIndex.Value, LoadSceneMode.Additive);
                        break;
                }
            }
            else
                return Status.Error;

            return Status.Success;
        }
    }
}