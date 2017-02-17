using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// manager class for a collection of LogicContainers
// evalutes and executes them...
// ** Script Execution Order must be before any LogicContainers **
public class DecisionManager : Singleton<DecisionManager> {

	public List<LogicContainer>	logicContainers;

    void Awake()
    {
        logicContainers = new List<LogicContainer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        ProcessLogic();
	}

    public void Register(LogicContainer container)
    {
        logicContainers.Add(container);
    }

    public void Deregister(LogicContainer container)
    {
        logicContainers.Remove(container);
    }

    public void ProcessLogic()
    {
        foreach (LogicContainer l in logicContainers)
        {
            l.ProcessLogic();
        }
    }
}
