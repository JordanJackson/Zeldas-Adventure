using UnityEngine;
using System.Collections;

public class TrueCondition : Condition {

	// trivial condition, it's always true.
	override public bool Evaluate()
	{
		return true;
	}

}
