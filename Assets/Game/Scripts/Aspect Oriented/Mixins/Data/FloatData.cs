using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatData : Data
{

    [SerializeField]
    private float data;

    public float maxValue;
    public float minValue;

    public float Data()
    {
        return data;
    }

    public void UpdateData(float delta)
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
