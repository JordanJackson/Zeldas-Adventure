using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsInventoryItem : Mixin
{

    public string itemName;

    public Sprite thumbnail;

    // base method to call when item selected in inventory view
    public virtual void Select()
    {
        Debug.Log(itemName + " Selected.");
    }
}
