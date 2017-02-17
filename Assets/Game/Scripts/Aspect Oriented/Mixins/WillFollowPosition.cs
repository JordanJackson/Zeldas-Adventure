using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WillFollowPosition : MonoBehaviour
{

    public Transform target;
    public bool useHysteresis;
    public float kh;

    void Update()
    {
        if (target != null)
        {
            if (useHysteresis)
            {
                this.transform.position += (target.position - this.transform.position) * kh * Time.deltaTime;
            }
            else
            {
                this.transform.position = Vector3.Lerp(target.position, this.transform.position, 1 / (Vector3.Distance(target.position, this.transform.position)));
            }
        }
        else
        {
            Debug.LogWarning("Target not set for WillFollowPosition on " + gameObject.name);
        }
    }
}
