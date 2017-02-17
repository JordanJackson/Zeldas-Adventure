using UnityEngine;
using System.Collections;

public class RotateResponse : Response {

	public float turnSpeed;
	public GameObject recipient;

	// rotating by turnSpeed
	override public void Execute ()
	{
		if (recipient != null)
		{
			recipient.transform.RotateAround (Vector3.up, turnSpeed * Time.deltaTime);
		}
	}
}
