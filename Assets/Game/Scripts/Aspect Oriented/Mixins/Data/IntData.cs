using UnityEngine;
using System.Collections;

public class IntData : Data {

    [SerializeField]
	private int data;

    public int maxValue;
    public int minValue;

    public int Data()
    {
        return data;
    }

    public void UpdateData(int delta)
    {
        data += delta;

        if (data > maxValue)
        {
            data = maxValue;
        }
        if (data < minValue)
        {
            data = minValue;
        }
    }
}
