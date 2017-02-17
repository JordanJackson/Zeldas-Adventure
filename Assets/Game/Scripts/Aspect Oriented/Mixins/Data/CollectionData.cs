using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollectionData : Data {

	public List<GameObject>	data;

	public GameObject GetDataItem(int i)
	{
		GameObject rval = null;
		if (i < data.Count)
			rval = data [i];

		return rval;
	}
	public void Insert(GameObject go)
	{
		data.Add(go);
	}

	public void Remove(GameObject go)
	{
		//todo - dhdh
	}
}
