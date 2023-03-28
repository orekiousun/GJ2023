using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;
using UnityEngine.UI;
using System;

public class ExitUI : UIBase {
    [ChildValueBind("ExitBtn", nameof(Button.onClick))]
    Action OnExitButton;

    [ChildValueBind("CancelBtn", nameof(Button.onClick))]
    Action OnCancelButton;

    public override void OnDisplay(object args) {
        OnExitButton = Exit;
        OnCancelButton = Cancel;
        CommitValue();
    }

    public void Exit() {
        Application.Quit();
    }

    public void Cancel() {
        UIManager.Instance.Close(this);
    }
}
