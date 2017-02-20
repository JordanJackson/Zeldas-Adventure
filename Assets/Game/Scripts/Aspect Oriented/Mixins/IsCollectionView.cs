using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsCollectionView : MonoBehaviour
{
    // turn this into master inventory view
    public string collectionName;

    private CollectionData collection;

    public List<IsInventorySlot> inventorySlots;

    public IsInventoryView owner;

    public void Initialize(IsInventoryView owner)
    {
        this.owner = owner;
        collection = owner.GetInventoryData().GetCollectionByName(collectionName);
        if (collection == null)
        {
            Debug.LogWarning("No collection of name " + collectionName + " in " + owner.inventoryName + ".");
        }

        IsInventorySlot[] slots = this.GetComponentsInChildren<IsInventorySlot>();
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].Initialize(this);
            inventorySlots.Add(slots[i]);
        }
    }

    public CollectionData GetCollectionData()
    {
        return collection;
    }

    public void UpdateCollectionView()
    {
        // handle updates to collection view here
        // update each inventory slot?
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            inventorySlots[i].UpdateInventorySlot();
        }
    }
}
