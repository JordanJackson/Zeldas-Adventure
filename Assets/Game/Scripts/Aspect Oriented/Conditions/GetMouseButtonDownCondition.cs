using UnityEngine;
using System.Collections;
using System;

public class GetMouseButtonDownCondition : Condition
{

    public int mouseButtonID;

    public override bool Evaluate()
    {
        return Input.GetMouseButtonDown(mouseButtonID);
    }
}
