using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IsEquipSlot : Mixin {

	public enum eSlotType
	{
		rightHand,
        leftHand,
		head,
		boot,
		chest
	};

	public eSlotType slotType;
	public IsEquipable currentEquip;			    //slotted obj
    public List<IsEquipable> attachedEquipment;

    void Start()
    {
        attachedEquipment = new List<IsEquipable>();
    }

    public void AddEquipment(IsEquipable equipment)
    {
        // ensure only one of each equipment name
        for (int i = 0; i < attachedEquipment.Count; i++)
        {
            if (attachedEquipment[i].Name == equipment.Name)
            {
                Destroy(equipment.gameObject);
                return;
            }
        }
        // add equipment to list
        attachedEquipment.Add(equipment);
    }

    public void TryEquip(IsEquipable equipment)
    {
        if (currentEquip == null)
        {
            currentEquip = equipment;
            equipment.gameObject.SetActive(true);
        }
    }

    public void Equip(IsEquipable equipment)
    {
        if (currentEquip == null)
        {
            currentEquip = equipment;
            equipment.gameObject.SetActive(true);
        }
        else if (currentEquip.Name == equipment.Name)
        {
            currentEquip = null;
            equipment.gameObject.SetActive(false);
        }
        else
        {
            currentEquip.gameObject.SetActive(false);
            currentEquip = equipment;
            currentEquip.gameObject.SetActive(true);
        }
    }
}
