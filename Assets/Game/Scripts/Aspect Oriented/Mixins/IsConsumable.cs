﻿using UnityEngine;
using System.Collections;

public class IsConsumable : Mixin {


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
					recipId.UpdateData(itemId.Data());
				}
			}
		}

        FloatData[] sourceBuffs = GetComponents<FloatData>();
        FloatData[] destBuffs = GetRecipient().GetComponents<FloatData>();

        foreach (FloatData sourceData in sourceBuffs)
        {
            foreach (FloatData destData in destBuffs)
            {
                if (sourceData.Name == destData.Name)
                {
                    destData.UpdateData(sourceData.Data());
                }
            }
        }

	}

    public void ItemSelect()
    {
        Consume();
    }

	public void Consume()
	{
        // 1) apply buffs
        ApplyBuffs();

        IsCountable isCountable = GetComponent<IsCountable>();
        if (isCountable)
        {
            isCountable.ChangeAmount(-1);
        }

        // 2) self destruct
        Destroy(this.gameObject);
	}
}
