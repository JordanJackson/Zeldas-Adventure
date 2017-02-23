//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Collections;
using BehaviourMachine;

namespace BehaviourMachineEditor {
    /// <summary>
    /// Class used to check when a new scene is loaded in the editor.
    /// </summary>
    [InitializeOnLoad]
    public static class LoadSceneUtility {

        private static string s_CurrentScene;

        /// <summary>
        /// Called whenever a new scene is loaded.
        /// </summary>
        public static event SimpleCallback onLoadScene;


        static LoadSceneUtility () {
            s_CurrentScene = SceneManager.GetActiveScene().name;
            EditorApplication.hierarchyWindowChanged += OnHierarchyWindowChanged;
        }

        /// <summary>
        /// Called whenever the HierarchyWindow changes.
        /// </summary>
        private static void OnHierarchyWindowChanged () {
            // The scene has changed?
            if (s_CurrentScene != SceneManager.GetActiveScene().name) {

                // Update scene name
                s_CurrentScene = SceneManager.GetActiveScene().name;

                // Notify listeners
                if (onLoadScene != null)
                    onLoadScene();
            }
        }
    }
}