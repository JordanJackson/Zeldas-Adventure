using UnityEngine;
using System.Collections;

public class DestroyResponse : Response {

	public GameObject recipient;

	override public void Execute()
	{
		Destroy (recipient);
	}
}
