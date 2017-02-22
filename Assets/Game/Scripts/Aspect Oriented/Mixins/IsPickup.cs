using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class IsPickup : Mixin 
{
    public string pickupCallBack;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<IsCollector>() != null)
        {

            GameObject touched = collider.gameObject;

            Mixin[] mixins = GetComponents<Mixin>();
            foreach (Mixin m in mixins)
            {
                m.SetRecipient(touched);
            }

            if (pickupCallBack != "")
                SendMessage(pickupCallBack);

            Destroy(this);
        }
        
    }
}
