using UnityEngine;
using System.Collections;

public class isLevitator : Mixin {

	public void Buff(GameObject go)
	{
		// apply a force/levitate the object who i am applying myself to?
		go.GetComponent<Rigidbody>().AddForce( new Vector3(0.0f, 1000.0f, 0.0f));
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
