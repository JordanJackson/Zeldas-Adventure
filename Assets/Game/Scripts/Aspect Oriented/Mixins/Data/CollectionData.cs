using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollectionData : Data {

    public string collectionName;

	public List<IsInventoryItem> items;

	public IsInventoryItem GetItemByIndex(int index)
	{
        IsInventoryItem targetItem = null;
		if (index < items.Count)
            targetItem = items[index];

		return targetItem;
	}

    public IsInventoryItem GetItemByName(string itemName)
    {
       for (int i = 0; i < items.Count; i++)
        {
            if (items[i].itemName == itemName)
            {
                return items[i];
            }
        }

        return null;
    }

    public void Insert(IsInventoryItem item)
	{
        items.Add(item);
	}

	public void Remove(IsInventoryItem item)
	{
        items.Remove(item);
	}
}
