using UnityEngine;
using System.Collections;

public class CollisionHelper : MonoBehaviour {

	public void OnCollisionEnter(Collision other)
	{
		Debug.Log ("collided with " + other.gameObject.name);

        // both parties' other needs to be recorded
        HasCollided hc = this.gameObject.AddComponent<HasCollided> ();
		if (hc != null)
			hc.other = other.gameObject;

        HasCollided hcOther = other.gameObject.AddComponent<HasCollided> ();
		if (hcOther != null)
			hcOther.other = this.gameObject;
	}
}
