//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using System.Collections;

namespace BehaviourMachine {

    /// <summary>
    /// Gets a valur from the list.
    /// </summary>
    [NodeInfo(  category = "Action/Blackboard/",
                icon = "Blackboard",
                description = "Gets a valur from the list")]
    public class DynamicListGet : ActionNode {

        /// <summary>
        /// The dynamic list to get the value.
        /// </summary>
        [VariableInfo(tooltip = "The dynamic list to get the value")]
        public DynamicList list;

        /// <summary>
        /// The index of the value in the list.
        /// </summary>
        [VariableInfo(tooltip = "The index of the value in the list")]
        public IntVar index;

        /// <summary>
        /// The variable store to list value.
        /// </summary>
        [VariableInfo(canBeConstant = false, tooltip = "The variable store to list value", fixedType = false)]
        public Variable variable;

        public override void Reset () {
            list = new ConcreteDynamicList();
            index = 0;
            variable = new Variable();
        }

        public override Status Update () {
            // Validate members
            if (list.isNone || index.isNone || variable.isNone)
                return Status.Error;

            // Add to the list?
            variable.genericValue = list[index.Value];

            return Status.Success;
        }

    }
}