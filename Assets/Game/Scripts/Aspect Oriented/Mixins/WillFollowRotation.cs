using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WillFollowRotation : MonoBehaviour
{

    public Transform target;

	void Update()
    {
        if (target != null)
        {
            this.transform.LookAt(target.transform);
        }
        else
        {
            Debug.LogWarning("Target not set for WillFollowPosition on " + gameObject.name);
        }
    }
}
