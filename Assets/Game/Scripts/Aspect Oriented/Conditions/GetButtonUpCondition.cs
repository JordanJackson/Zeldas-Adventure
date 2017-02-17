using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetButtonUpCondition : Condition
{

    public string buttonName;

    public override bool Evaluate()
    {
        if (Input.GetButtonUp(buttonName))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
