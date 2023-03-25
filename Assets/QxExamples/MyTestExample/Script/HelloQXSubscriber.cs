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
        // HelloQXMessageType.First���Ƕ�������Ҫ��Ӧ����Ϣ����FirstQXFunction���ǽ��յ���Ϣ����Ҫִ�еĲ���
        MessageManager.Instance.Get<HelloQXMessageType>().RegisterHandler(HelloQXMessageType.First, FirstQXFunction);
    }

    private void FirstQXFunction(object sender, EventArgs e)
    {
        Debug.Log("FirstQXFunction");
        HelloQxEventArgs temp = (HelloQxEventArgs)e;
        Debug.Log(temp.name + " -- " + temp.description);
    }
}
