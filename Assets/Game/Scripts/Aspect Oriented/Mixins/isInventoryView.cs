using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class isInventoryView : MonoBehaviour {

	public string Name; // name of the collection we are binding to
	private CollectionData collection;

	public List<isInventorySlot>	slots; 

	public GameObject parent;

	public void OnEnable()
	{
		// find the collection we need
		if (parent != null) {
			CollectionData[] cds = parent.GetComponentsInChildren<CollectionData> ();
			foreach (CollectionData cd in cds)
				if (cd.Name == Name)
					collection = cd;
		} else
			Debug.Log ("isInventoryView::OnEnable() ERROR PARENT IS NULL");

		// populate 
		isInventorySlot[] sls = this.gameObject.GetComponentsInChildren<isInventorySlot>();
		foreach (isInventorySlot s in sls)
			slots.Add (s);

	}

	// Use this for initialization
	void Start () {
	
	}

	public void isInventoryViewUpdate()
	{
		// map slot image thumbnails to inventory object thumbnails
		// brute force!
		if (collection != null) 
		{
			int i = 0;
			foreach (isInventorySlot iis in slots)
			{
				// what if collection.size < slots.size
				GameObject obj = collection.GetDataItem(i);//data [i];
				if (obj != null)
				{
					hasThumbnail ht = obj.GetComponent<hasThumbnail> ();
					if (ht != null)
					{
						// if we have a thumbnail, associate this obj with our slot
						Image slotImage = iis.gameObject.GetComponent<Image>();
						if (slotImage != null)
						{
							slotImage.overrideSprite = ht.img;
							iis.obj = obj; // keep reference to collection obj in the slot
						}
					}
				}
				i++;
			}
		}
	}

	// Update is called once per frame
	void Update () {
	
		isInventoryViewUpdate ();
	}
}
