using System;

namespace NameList {
    public enum Layer {  // 名字和编号需要与Unity中的相等
        Default = 0,
        TransparentFX = 1,
        IgnoreRaycast = 2,
        Ground = 3,
        Water = 4,
        UI = 5,
        Player = 6,
    }
    public enum UI {
        StartUI = 0,
        TipUI = 1,
        ExitUI = 2,
        StatusUI = 3,
    }
}