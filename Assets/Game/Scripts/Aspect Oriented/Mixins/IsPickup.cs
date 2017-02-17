using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class IsPickup : IsTouchable 
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<IsConsumer>() != null)
        {
            GameObject touched = collider.gameObject;

            Mixin[] mixins = GetComponents<Mixin>();
            foreach (Mixin m in mixins)
            {
                m.SetRecipient(touched);
            }

            if (OnTouchCB != "")
                SendMessage(OnTouchCB);
        }
        
    }
}
