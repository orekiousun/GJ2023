using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;
using UnityEngine.UI;
using System;
using NameList;

public class StartUI : UIBase {
    [ChildValueBind("EnterBtn", nameof(Button.onClick))]
    Action OnEnterButton;

    [ChildValueBind("ExitBtn", nameof(Button.onClick))]
    Action OnExitButton;

    public override void OnDisplay(object args) {
        OnEnterButton = StartGame;
        OnExitButton = Exit;
        // CommitValue();
    }

    public void StartGame() {
        ProcedureManager.Instance.ChangeTo<GameProcedure>();
        UIManager.Instance.Close(this);
    }

    public void Exit() {
        UIManager.Instance.Open(NameList.UI.ExitUI.ToString());
    }
}
