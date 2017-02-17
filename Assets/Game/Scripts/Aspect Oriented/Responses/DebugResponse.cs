using UnityEngine;
using System.Collections;

public class DebugResponse : Response {

	public string debugMsg; // msg to display on Debug.Log..

	override public void Execute()
	{
		Debug.Log (debugMsg);
	}
}
