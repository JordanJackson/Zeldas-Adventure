using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    IsEquipSlot weaponSlot;

    void Start()
    {
        IsEquipSlot[] equipSlots = GetComponentsInChildren<IsEquipSlot>();
        for (int i = 0; i < equipSlots.Length; i++)
        {
            if (equipSlots[i].slotType == IsEquipSlot.eSlotType.rightHand)
            {
                weaponSlot = equipSlots[i];
                break;
            }
        }

        // wake all InventoryViews
        IsInventoryView[] inventoryViews = FindObjectsOfType<IsInventoryView>();
        foreach (IsInventoryView iV in inventoryViews)
        {
            iV.gameObject.SetActive(true);
            iV.enabled = true;
        }
    }

	void Update()
    {
        UpdateWeaponSize();
    }

    void UpdateWeaponSize()
    {
        if (weaponSlot.currentEquip != null)
        {
            FloatData[] dataArr = GetComponents<FloatData>();
            for (int i = 0; i < dataArr.Length; i++)
            {
                if (dataArr[i].Name == "Weapon Size")
                {
                    float size = dataArr[i].Data();
                    weaponSlot.currentEquip.transform.localScale = new Vector3(size, size, size);
                    break;
                }
            }

        }
    }
}
