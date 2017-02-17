using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetButtonCondition : Condition
{

    public string buttonName;

    public override bool Evaluate()
    {
        if (Input.GetButton(buttonName))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}