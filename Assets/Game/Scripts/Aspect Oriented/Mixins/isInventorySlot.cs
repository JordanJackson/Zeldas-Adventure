using UnityEngine;
using System.Collections;

public class isInventorySlot : MonoBehaviour {

	public GameObject obj; //  object back prt to collection

	public void OnMouseDown()
	{
		isUsable iu = obj.GetComponent<isUsable> ();
		if (iu != null)
		{
			// fix disabled object sendmessage failure! 
			if (obj != null)
				obj.SetActive (true);

			iu.Use ();
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
