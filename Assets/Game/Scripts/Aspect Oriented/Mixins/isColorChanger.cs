using UnityEngine;
using System.Collections;

public class isColorChanger : MonoBehaviour {

	public Color c;

	public void Buff(GameObject go)
	{
		MeshRenderer mr = go.GetComponent<MeshRenderer> ();
		if (mr != null)
		{
			mr.material.color = c;
		}
			
	}
}
