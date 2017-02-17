using UnityEngine;
using System.Collections;

public class DestroyOtherResponse : Response {

	override public void Execute ()
	{
        // if I collided with someone, it means my other is someone
        // destroy my other
        HasCollided ch = this.gameObject.GetComponentInParent<HasCollided>();
		if (ch != null) {
			GameObject otherObj = ch.other;
			if (otherObj != null)
				Destroy (otherObj);
		}
	}
}
