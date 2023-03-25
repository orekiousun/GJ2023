using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;

public class SecondProcedure : ProcedureBase
{
    /// <summary>
    /// ��дInit������
    /// </summary>
    protected override void OnInit()
    {
        base.OnInit();
        Debug.Log("SecondProcedure Init");
    }

    /// <summary>
    /// ��д��������ʱ�ĺ���
    /// </summary>
    /// <param name="args">��ʱ��֪����ɶ</param>
    protected override void OnEnter(object args)
    {
        base.OnEnter(args);
        Debug.Log("SecondProcedure Enter");
        if(args is string _stringArgs)
        {
            // ��һ�仰ֱ���ж������Ͳ�����������ת����_stringArgs����ת����ı���
            Debug.Log(_stringArgs);
        }
    }
}
