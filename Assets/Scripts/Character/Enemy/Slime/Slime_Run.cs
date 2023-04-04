using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Slime_Run", menuName = "States/Slime/Slime_Run")]
public class Slime_Run : EnemyStateBase {
    [SerializeField] private float attackDistance;
    [SerializeField] private float accelerateSpeed;

#region override
    public override void OnEnter() {
        PlayAnimation();   // 播放奔跑动画，待完成
    }

    public override void OnUpdate() {
        if(enemy.Target == null) {  // 如果丢失目标，就回到静止状态
            controller.ChangeState(EnemyStateEnum.Idle);
        }
        else if (Vector3.Distance(enemy.transform.position, enemy.Target.transform.position) < attackDistance)
        {                           // 如果处于攻击范围，就切换到攻击状态
            controller.ChangeState(EnemyStateEnum.Attack);
        }
        else {                      // 否则，执行追击敌人的逻辑
            enemy.ChangeFacing(enemy.Target.position.x);
            enemy.ChangeSpeed(accelerateSpeed);
        }
    }

    public override void OnExit() {
        
    }
#endregion
}
