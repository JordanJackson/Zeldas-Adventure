using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsKey : IsInventoryItem
{

    public override void Select()
    {
        base.Select();

        // try to use on door?
        // or do nothing and let use on door decrement key count
    }
}
