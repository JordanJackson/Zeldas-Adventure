using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class AnimatorSetTriggerResponse : Response 
{

    public string triggerName;

    Animator animator;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        if (animator == null)
        {
            Debug.LogWarning("No default Animator for " + gameObject.name);
            animator = gameObject.AddComponent<Animator>();
        }
    }

    public override void Execute()
    {
        animator.SetTrigger(triggerName);
    }
}
