using UnityEngine;
using System.Collections;

public class IsConsumable : Mixin {

	// to consume something means to
	//  1) apply +/- buffs to any attributes (we dont have any yet)
	//  2) self destruct

	public void ApplyBuffs()
	{
		// todo - dhdh
		//SendMessage("Buff", GetRecipient());

		// search for attributes we can modify...based on names, and apply them
		IntData[] SrcBuffs = GetComponents<IntData>();
		IntData[] DestBuffs = GetRecipient().GetComponents<IntData> ();

		foreach (IntData itemId in SrcBuffs)
		{
			foreach (IntData recipId in DestBuffs)
			{
				// do the work if the name is the same omg
				if (itemId.Name == recipId.Name)
				{
					// apply delta
					recipId.data += itemId.data;
				}
			}
		}

	}

	public void Consume()
	{
        // 1) apply buffs
        ApplyBuffs();

        // 2) self destruct
        Destroy(this.gameObject);
	}
}
