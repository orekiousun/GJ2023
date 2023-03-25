using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;

public class HelloQXProcedure : ProcedureBase
{
    /// <summary>
    /// ��дInit������
    /// </summary>
    protected override void OnInit()
    {
        base.OnInit();
        Debug.Log("HelloQXProcedure Init");
    }

    /// <summary>
    /// ��д��������ʱ�ĺ���
    /// </summary>
    /// <param name="args">��ʱ��֪����ɶ</param>
    protected override void OnEnter(object args)
    {
        base.OnEnter(args);
        Debug.Log("HelloQXProcedure Enter");
        GameMgr.Instance.InitModules();
        // Ϊ�������HelloQxSubModuleģ��
        AddSubmodule(new HelloQxSubModule());
    }
}
