using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;


public class EnemyStateBase : ScriptableObject {
    public EnemyBase enemy;
    public EnemyStateEnum state;
    protected EnemyStateController controller;
    public virtual void OnEnter() {

    }
    public virtual void OnUpdate() {
    }

    public virtual void OnExit() {

    }

    public void SetController(EnemyStateController newController) {
        controller = newController;
    }

    public void SetEnemy(EnemyBase newEnemy) {
        enemy = newEnemy;
    }

    protected void PlayAnimation() {
        // 还没写，需要结合动画状态机
    }
}
