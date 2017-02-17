using UnityEngine;
using System.Collections;

// base aspect
public class Mixin : MonoBehaviour {

	public string Name;
	private GameObject recipient;	//hey, familiar!

	public void SetRecipient(GameObject r)
	{
		// clobbers old value by design
		recipient = r;
	}

	public GameObject GetRecipient()
	{
		// caller checks for null
		return recipient;
	}
}
