using UnityEngine;
using System.Collections;

public class isUsable : Mixin {

	public string OnUseCB;

	public void Use()
	{
		SendMessage (OnUseCB);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
