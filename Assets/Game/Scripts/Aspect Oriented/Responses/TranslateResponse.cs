using UnityEngine;
using System.Collections;

public class TranslateResponse : Response {

	public float speed;
	public Vector3 vDir;
	public GameObject recipient;

	override public void Execute ()
	{
		if (recipient != null)
			recipient.transform.Translate (speed * Time.deltaTime * vDir);
	}
}
