using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsInventoryView : Mixin
{
    public string inventoryName;

    public InventoryData inventoryData;

    public List<IsCollectionView> collectionViews;

    public GameObject owner;

    public int gridWidth = 2;
    public int gridHeight = 2;

    void OnEnable()
    {
        Initialize();
    }

    void Update()
    {
        UpdateInventoryView();
    }

    void Initialize()
    {
        // find inventory data
        if (owner)
        {
            InventoryData[] inventories = owner.GetComponentsInChildren<InventoryData>();
            for (int i = 0; i < inventories.Length; i++)
            {
                if (inventories[i].inventoryName == inventoryName)
                {
                    inventoryData = inventories[i];
                    break;
                }
            }
            if (!inventoryData)
            {
                Debug.LogWarning("InventoryData of name " + inventoryName + " not found for GameObject " + owner.name);
            }
        }
        else
        {
            Debug.LogWarning("InventoryView for " + inventoryName + " does not have owner GameObject set.");
        }

        IsCollectionView[] views = this.GetComponentsInChildren<IsCollectionView>();
        for (int i = 0; i < views.Length; i++)
        {
            views[i].Initialize(this);
            collectionViews.Add(views[i]);
        }
    }

    public InventoryData GetInventoryData()
    {
        return inventoryData;
    }

    void UpdateInventoryView()
    {
        for (int i = 0; i < collectionViews.Count; i++)
        {
            collectionViews[i].UpdateCollectionView();
        }
    }
}
