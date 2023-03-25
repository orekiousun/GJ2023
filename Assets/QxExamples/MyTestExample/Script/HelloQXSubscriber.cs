using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;
using System;

public enum HelloQXMessageType
{
    First,
    Second
}


public class HelloQXSubscriber:MonoBehaviour
{
    private void Awake()
    {
        // HelloQXMessageType.First则是订阅者需要响应的消息，而FirstQXFunction则是接收到消息后需要执行的操作
        MessageManager.Instance.Get<HelloQXMessageType>().RegisterHandler(HelloQXMessageType.First, FirstQXFunction);
    }

    private void FirstQXFunction(object sender, EventArgs e)
    {
        Debug.Log("FirstQXFunction");
        HelloQxEventArgs temp = (HelloQxEventArgs)e;
        Debug.Log(temp.name + " -- " + temp.description);
    }
}
