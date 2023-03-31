using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Slime_BeAttacked", menuName = "States/Slime/Slime_BeAttacked")]
public class Slime_BeAttacked : EnemyStateBase {


#region override
    public override void OnEnter() {
        PlayAnimation();   // 播放受击动画，待完成
    }

    public override void OnUpdate() {
        enemy.ChangeSpeed(0, true);
    }

    public override void OnExit() {
        
    }
#endregion
}
