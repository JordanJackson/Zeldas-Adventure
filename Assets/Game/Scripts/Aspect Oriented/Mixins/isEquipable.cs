using UnityEngine;
using System.Collections;

public class IsEquipable : Mixin {

	public IsEquipSlot.eSlotType slotType;
    public bool autoEquip = true;

    IsEquipSlot equipSlot;

    public void ItemSelect()
    {
        ToggleEquip();
    }

	public void AttachToSlot(GameObject newParent)
	{
        // find appropriate equipment slot and attach to it
        IsEquipSlot[] equipSlots = newParent.GetComponentsInChildren<IsEquipSlot>();

        for (int i = 0; i < equipSlots.Length; i++)
        {
            if (equipSlots[i].slotType == this.slotType)
            {
                this.transform.SetParent(equipSlots[i].transform);
                this.transform.localPosition = Vector3.zero;
                this.transform.localRotation = Quaternion.identity;
                equipSlot = equipSlots[i];
                equipSlot.AddEquipment(this);

                if (autoEquip)
                {
                    equipSlot.TryEquip(this);
                }

                break;
            }
        }
	}

    void ToggleEquip()
    {
        if (equipSlot != null)
        {
            equipSlot.Equip(this);
        }
    }
}
