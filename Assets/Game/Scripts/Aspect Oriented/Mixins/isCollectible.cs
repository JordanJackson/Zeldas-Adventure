using UnityEngine;
using System.Collections;

public class IsCollectible : Mixin {

	public void Collect()
	{
        IsInventoryItem item = this.GetComponent<IsInventoryItem>();

        if (item != null)
        {
            if (item.AddToInventory(GetRecipient()))
            {
                Destroy(this);
            }
        }
	}

}
