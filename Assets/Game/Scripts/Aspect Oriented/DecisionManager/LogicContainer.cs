using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Container for all Logic attached to a GameObject
// To be registered with the DecisionManager
// ** Script Execution Order must after DecisionManager **
public class LogicContainer : MonoBehaviour
{

    public List<Logic> logicList;

    public void ProcessLogic()
    {
        foreach (Logic l in logicList)
        {
            l.Evaluate();
        }
    }

    void OnEnable()
    {
        // register with DecisionManager
        DecisionManager.Instance.Register(this);
    }

    void OnDestroy()
    {
        // de-register with DecisionManager
        DecisionManager.Instance.Deregister(this);
    }
}
