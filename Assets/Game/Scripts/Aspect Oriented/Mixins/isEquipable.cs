using UnityEngine;
using System.Collections;

public class isEquipable : Mixin {

	public isEquipSlot.eSlotType slotType;

	public void Equip()
	{
		// find the first open slot of my compatible type, and 
		// equip me there!

		isEquipSlot[] eqSlots = GetRecipient ().GetComponentsInChildren<isEquipSlot> ();

		foreach (isEquipSlot iseqs in eqSlots)
		{
			// slot type matches
			if (iseqs.slotType == slotType)
			{
				// slot is empty
				if (iseqs.obj == null)
				{
					// insert it!
					this.transform.parent = iseqs.transform;

					this.transform.localPosition = Vector3.zero;

					// make rb enert... ug...todo
					Rigidbody rb = this.gameObject.GetComponent <Rigidbody> ();

					if (rb != null) {
						rb.isKinematic = true;
					}
					iseqs.obj = this.gameObject; //api!
					break;
				}
			}
		}

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
