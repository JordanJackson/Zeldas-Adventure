using UnityEngine;
using System.Collections;

public class InstantiateResponse : Response {

	public GameObject obj;
	public GameObject spawnLoc;

	override public void Execute()
	{
		if (obj != null)
			Instantiate (obj, spawnLoc.transform.position, spawnLoc.transform.rotation);
	}
}
