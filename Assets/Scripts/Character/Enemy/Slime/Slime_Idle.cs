using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;

[CreateAssetMenu(fileName = "Slime_Idle", menuName = "States/Slime/Slime_Idle")]
public class Slime_Idle : EnemyStateBase {
    [SerializeField] private float accelerateSpeed = 0f;

#region override
    public override void OnEnter() {
        PlayAnimation();   // 播放站立动画，待完成
    }

    public override void OnUpdate() {
        if(enemy.Target != null) {   // 如果检测到了目标，就退出当前状态，去追击目标
            controller.ChangeState(EnemyStateEnum.Run);
        }
        else {                       // 否则，执行静止的逻辑
            enemy.ChangeSpeed(accelerateSpeed, true);
        }
    }

    public override void OnExit() {
        
    }
#endregion
}
