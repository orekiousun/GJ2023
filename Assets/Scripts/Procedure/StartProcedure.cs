using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;
using NameList;

public class StartProcedure : ProcedureBase {
    protected override void OnInit() {
        base.OnInit();
    }

    protected override void OnEnter(object args) {
        base.OnEnter(args);
        UIManager.Instance.Open(NameList.UI.StartUI.ToString(), args: "xxx游戏");
    }

    protected override void OnLeave() {
        
    }
}
