using UnityEngine;
using System.Collections;

public class Debuggable : Mixin {

	public void DebugMe ()
	{
		Debug.Log ("FOO!");
	}
}
