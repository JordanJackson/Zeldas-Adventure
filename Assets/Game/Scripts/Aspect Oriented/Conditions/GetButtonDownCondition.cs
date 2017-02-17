using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetButtonDownCondition : Condition
{

    public string buttonName;

    public override bool Evaluate()
    {
        if (Input.GetButtonDown(buttonName))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}