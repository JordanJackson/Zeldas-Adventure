using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsCountable : Mixin
{
    public int value = 1;
    public int currentAmount;
    public int maxAmount;
    public int minAmount = 0;

    public int countHorizontalOffset;
    public int countVerticalOffset;
    public int countScale = 12;
    public Color countColor = Color.grey;

    public Font countFont;

    public void ChangeAmount(int delta)
    {
        currentAmount += delta;
        if (currentAmount > maxAmount)
        {
            currentAmount = maxAmount;
        }
        if (currentAmount < minAmount)
        {
            currentAmount = minAmount;
        }
    }
}
