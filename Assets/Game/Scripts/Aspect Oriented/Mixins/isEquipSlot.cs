using UnityEngine;
using System.Collections;

public class isEquipSlot : Mixin {

	public enum eSlotType
	{
		eHand,
		eHead,
		eBoot,
		eChest
	};

	public eSlotType slotType;
	public GameObject obj;			//slotted obj
}
