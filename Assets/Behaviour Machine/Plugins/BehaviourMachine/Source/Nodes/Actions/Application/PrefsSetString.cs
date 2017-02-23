//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using System.Collections;

namespace BehaviourMachine {

    /// <summary>
    /// Sets the value of the preference identified by "Key".
    /// </summary>
    [NodeInfo ( category = "Action/Application/",
                icon = "GameManager",
                description = "Sets the value of the preference identified by \"Key\"",
                url = "http://docs.unity3d.com/Documentation/ScriptReference/PlayerPrefs.SetString.html")]
    public class PrefsSetString : ActionNode {

        /// <summary>
        /// Key name.
        /// </summary>
        [VariableInfo (tooltip = "Key name")]
        public StringVar key;

        /// <summary>
        /// The new value.
        /// </summary>
        [VariableInfo(tooltip = "The new value")]
        public StringVar newValue;

        public override void Reset () {
            key = new ConcreteStringVar();
            newValue = new ConcreteStringVar();
        }

        public override Status Update () {
            // Validate Members
            if (key.isNone || newValue.isNone)
                return Status.Error;

            PlayerPrefs.SetString(key.Value, newValue.Value);
            return Status.Success;
        }
    }
}