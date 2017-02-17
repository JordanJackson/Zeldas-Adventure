using UnityEngine;
using System.Collections;

public class WaitCondition : Condition {

	public float waitDuration;
	private float t;
	private bool started;

	// trivial condition, it's always true.
	override public bool Evaluate()
	{
		bool rval = false;

		if (started == false)
		{
			started = true;
			t = waitDuration;
		}

		if (started == true)
		{
			t -= Time.deltaTime;
			if (t <= 0.0f)
				rval = true;
		}

		return rval;
	}
}
