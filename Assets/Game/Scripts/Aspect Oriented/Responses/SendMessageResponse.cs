using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendMessageResponse : Response
{

    public string messageString;

    public override void Execute()
    {
        Debug.Log("Message: " + messageString);
        SendMessage(messageString);
    }
}
