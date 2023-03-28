using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;

public class GameProcedure : ProcedureBase {
    protected override void OnInit() {
        base.OnInit();
    }

    protected override void OnEnter(object args) {
        base.OnEnter(args);
        UIManager.Instance.Open(NameList.UI.TipUI.ToString(), args: "xx场景");
        // GameMgr.SceneMgr.ChangeScene();
    }

    protected override void OnLeave() {
        
    }
}
