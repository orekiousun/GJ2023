using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;

public class GameProcedure : ProcedureBase {
    protected override void OnInit() {
    }

    protected override void OnEnter(object args) {
        GameMgr.Instance.InitModules();
        GameMgr.SceneMgr.ChangeScene("GamePlay");
    }

    protected override void OnLeave() {
        
    }
}
