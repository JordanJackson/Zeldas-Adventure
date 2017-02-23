using UnityEngine;
using System.Collections;

namespace BehaviourMachine {

    /// <summary>
    /// Applies a jolt of force to the Game Object's position and returns it back to its original position.
    /// </summary>
    [NodeInfo(  category = "Action/Tween/",
                icon = "Tween",
                description = "Applies a jolt of force to the Game Object\'s position and returns it back to its original position")]
    public class PunchPosition : TweenGameObjectNode {

        /// <summary>
        /// Amount to punch the position.
        /// </summary>
        [VariableInfo(tooltip = "Amount to punch the position")]
        public Vector3Var amount;

        /// <summary>
        /// For whether to animate in world space or relative to the parent.
        /// </summary>
        [Tooltip("For whether to animate in world space or relative to the parent")]
        public bool isLocal = false;

        [System.NonSerialized]
        Vector3 m_LastPosition = Vector3.zero;

        [System.NonSerialized]
        Space m_Space;

        public override void Reset () {
            base.Reset();
            amount = new ConcreteVector3Var();
        }

        public override void OnStart () {
            m_Space = isLocal ? Space.Self : Space.World;

            Vector3 from = isLocal ? transform.localPosition : transform.position;
            Vector3 to = amount.Value;

            m_From = new float[] {from.x, from.y, from.z};
            m_To = new float[] {to.x, to.y, to.z};
            m_Result = new float[] {0f, 0f, 0f};
        }

        public override void OnFinish () {
            // transform.position = new Vector3(m_From[0], m_From[1], m_From[2]);
        }

        public override void OnUpdate () {
            ApplyPunch();

            // Apply
            Vector3 result = new Vector3(m_Result[0], m_Result[1], m_Result[2]);
            transform.Translate(result - m_LastPosition, m_Space);

            // Record
            m_LastPosition = result;
        }
    }
}