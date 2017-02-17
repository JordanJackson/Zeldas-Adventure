using UnityEngine;
using System.Collections;

public class GetKeyCondition : Condition {

	public KeyCode key;

	// returns true if it's down, false otherwise
	override public bool Evaluate()
	{
		bool rval = false;

		if (Input.GetKey (key) == true) {
			rval = true;
		}

		return rval;
	}
}
