using UnityEngine;
using System.Collections;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class NavMeshAgentSetPathResponse : Response
{
    UnityEngine.AI.NavMeshAgent agent;
    UnityEngine.AI.NavMeshPath path;

    int lm;

    void Awake()
    {
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Start()
    {
        // inverted layermask of player layer
        lm = ~(1 << agent.gameObject.layer);
    }

    public override void Execute()
    {
        // create a Raycast and set it to the mouses cursor position in game
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, lm))
        {
            path = new UnityEngine.AI.NavMeshPath();
            if (agent.CalculatePath(hit.point, path))
            {
                agent.SetPath(path);
            }
            else
            {
                path = null;
            }
        }
    }
}
