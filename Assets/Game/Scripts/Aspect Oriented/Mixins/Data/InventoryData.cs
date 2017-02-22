using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryData : Data
{
    public string inventoryName;

    public List<CollectionData> collections;

    public CollectionData GetCollectionByIndex(int index)
    {
        CollectionData targetCollection = null;
        if (index < collections.Count)
            targetCollection = collections[index];

        return targetCollection;
    }

    public void Insert(CollectionData collection)
    {
        collections.Add(collection);
    }

    public void Remove(CollectionData collection)
    {
        collections.Remove(collection);
    }

    public CollectionData GetCollectionByName(string collectionName)
    {
        for (int i = 0; i < collections.Count; i++)
        {
            if (collections[i].collectionName == collectionName)
            {
                return collections[i];
            }
        }
        // no collection with that name
        return null;
    }
}
