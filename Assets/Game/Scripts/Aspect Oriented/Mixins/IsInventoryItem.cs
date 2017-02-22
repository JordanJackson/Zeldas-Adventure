using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsInventoryItem : Mixin
{

    public string itemName;
    public string collectionName;
    public string inventoryName;

    // base method to call when item selected in inventory view
    public void Select()
    {
        Debug.Log(itemName + " Selected.");

        gameObject.SetActive(true);
        SendMessage("ItemSelect");


    }

    public bool AddToInventory(GameObject newParent)
    {
        InventoryData[] inventories = newParent.GetComponentsInChildren<InventoryData>();

        for (int i = 0; i < inventories.Length; i++)
        {
            if (inventories[i].inventoryName == this.inventoryName)
            {
                CollectionData collection = inventories[i].GetCollectionByName(collectionName);
                if (collection != null)
                {
                    collection.Insert(this);
                    this.gameObject.SetActive(false);
                    // check for other mixins here?

                    IsEquipable equipable = this.GetComponent<IsEquipable>();
                    if (equipable)
                    {
                        equipable.AttachToSlot(newParent);
                    }

                    return true;
                }
                else
                {
                    Debug.Log("No collection " + collectionName + " on touched GameObject " + newParent.name + ".");
                    return false;
                }

            }
        }

        Debug.Log("No inventory " + inventoryName + " on touched GameObject " + newParent.name + ".");
        return false;
    }
}
