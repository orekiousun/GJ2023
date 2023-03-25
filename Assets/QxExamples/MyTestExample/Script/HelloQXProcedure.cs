using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;

public class HelloQXProcedure : ProcedureBase
{
    /// <summary>
    /// 重写Init函数。
    /// </summary>
    protected override void OnInit()
    {
        base.OnInit();
        Debug.Log("HelloQXProcedure Init");
    }

    /// <summary>
    /// 重写进入流程时的函数
    /// </summary>
    /// <param name="args">暂时不知道是啥</param>
    protected override void OnEnter(object args)
    {
        base.OnEnter(args);
        Debug.Log("HelloQXProcedure Enter");
        GameMgr.Instance.InitModules();
        // 为流程添加HelloQxSubModule模块
        AddSubmodule(new HelloQxSubModule());
    }
}
