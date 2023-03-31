using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Slime_Wander", menuName = "States/Slime/Slime_Wander")]
public class Slime_Wander : EnemyStateBase {
    private bool firstEnter = true;
    private Vector2 originPosition;
    [SerializeField] private float wanderRadius;
    [SerializeField] private float wanderSpeed;
    private Vector2 leftBoundary;
    private Vector2 rightBoundary;

#region override
    public override void OnEnter() {
        PlayAnimation();   // 播放巡逻动画，待完成
        if(!firstEnter) return;
        originPosition = enemy.transform.position;
        leftBoundary =  new Vector2(originPosition.x - wanderRadius, originPosition.y);
        rightBoundary =  new Vector2(originPosition.x + wanderRadius, originPosition.y);
        firstEnter = false;
    }

    public override void OnUpdate() {
        if(enemy.isFacingLeft) {   // 如果面向左边
            if(Vector2.Distance(enemy.transform.position, leftBoundary) >= 0.1)
                enemy.ChangeSpeed(-wanderSpeed);
            else
                enemy.ChangeFacing(originPosition.x);
        }
        else {                     // 如果面向右边
            if(Vector2.Distance(enemy.transform.position, rightBoundary) >= 0.1)
                enemy.ChangeSpeed(wanderSpeed);
            else
                enemy.ChangeFacing(originPosition.x);
        }
    }

    public override void OnExit() {
        
    }
#endregion
}
