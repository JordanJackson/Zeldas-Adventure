using UnityEngine;
using System.Collections;

public class IsCollectible : Mixin {

	public void Collect()
	{
		// put me in the collection that matches my name
		// we HAVE a recipient now, cuz we updated istouchable...
		// try and insert!
		CollectionData []cdatas = GetRecipient().GetComponents<CollectionData>();

		foreach (CollectionData cd in cdatas)
		{
			// insert
			if (cd.Name == Name) {
				cd.Insert (this.gameObject);

				// do some sort of disable, so we don't collect it again
				this.gameObject.SetActive (false);
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
