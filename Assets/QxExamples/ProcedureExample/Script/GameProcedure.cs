﻿using QxFramework.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProcedure : ProcedureBase {

    protected override void OnEnter(object args)
    {
        base.OnEnter(args);
        AddSubmodule(new GameControlModule());
    }

    protected override void OnLeave()
    {
        base.OnLeave();
    }
}
