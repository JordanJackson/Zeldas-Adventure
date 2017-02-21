using UnityEngine;
using System.Collections;

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
	public GameObject obj;			//slotted obj
}
