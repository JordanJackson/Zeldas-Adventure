using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Inventory/List", order = 1)]
[System.Serializable]
public class InventoryItem : ScriptableObject
{
    public IsInventoryItem item;
}
