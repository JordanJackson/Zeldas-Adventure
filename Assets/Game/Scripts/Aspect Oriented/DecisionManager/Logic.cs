using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Logic {

	public Condition cond;
	public List<Response> resp;

	// evaluates the condition, and if it is true, executes the response
	public bool Evaluate()
	{
		bool rval = false;

		if (cond != null)
		{
			if (cond.Evaluate())
			{
				foreach (Response r in resp)
				{
					if (r != null)
					{
						r.Execute ();
						rval = true;
					}
				}
			}
		}

		return rval;
	}
}
