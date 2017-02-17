using UnityEngine;
using System.Collections;

public class Debugable : Mixin {

	public void DebugMe ()
	{
		Debug.Log ("FOO!");
	}
}
