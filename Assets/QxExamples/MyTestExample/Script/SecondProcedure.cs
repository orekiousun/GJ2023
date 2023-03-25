using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;

public class SecondProcedure : ProcedureBase
{
    /// <summary>
    /// 重写Init函数。
    /// </summary>
    protected override void OnInit()
    {
        base.OnInit();
        Debug.Log("SecondProcedure Init");
    }

    /// <summary>
    /// 重写进入流程时的函数
    /// </summary>
    /// <param name="args">暂时不知道是啥</param>
    protected override void OnEnter(object args)
    {
        base.OnEnter(args);
        Debug.Log("SecondProcedure Enter");
        if(args is string _stringArgs)
        {
            // 这一句话直接判断了类型并进行了类型转换，_stringArgs就是转换后的变量
            Debug.Log(_stringArgs);
        }
    }
}
