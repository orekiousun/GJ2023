using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;

public class HelloQxSubModule : Submodule
{
    protected override void OnInit()
    {
        base.OnInit();
        Debug.Log("HelloQxSubModule Init");
        OpenUI("HelloQXUI");
        // ProcedureManager.Instance.ChangeTo<SecondProcedure>("Try to Send Temp Args");
    }
}
