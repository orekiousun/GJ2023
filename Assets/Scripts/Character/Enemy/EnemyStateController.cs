using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;

public enum EnemyStateEnum {
    Idle = 0,
    Run = 1,
    Wander = 2,
    Attack = 3,
    BeAttacked = 4,
}

public class EnemyStateController : MonoBehaviour {
    [SerializeField] private List<EnemyStateBase> states = new List<EnemyStateBase>();
    // 需要在Inspector面板里手动添加状态
    private Dictionary<EnemyStateEnum, int> statesIndex = new Dictionary<EnemyStateEnum, int>();
    // 用于记录状态的索引，方便直接从states中获取
    private EnemyBase enemy;
    public EnemyStateEnum currentState;
    public EnemyStateEnum lastState;
    [SerializeField] private EnemyStateEnum defaultState;
    public float currentStateTime = 0f;

    /// <summary>
    /// 切换状态
    /// </summary>
    /// <param name="newState">新状态</param>
    public void ChangeState(EnemyStateEnum newState) {
        // 退出上一状态
        lastState = currentState;
        states[statesIndex[lastState]].OnExit();

        // 进入新的状态
        currentState = newState;
        states[statesIndex[currentState]].OnEnter();
        currentStateTime = 0f;
    }

    /// <summary>
    /// 初始化状态控制机
    /// </summary>
    public void InitController() {
        enemy = GetComponent<EnemyBase>();
        // 初始化当前状态
        currentState = defaultState;
        lastState = defaultState;
        currentStateTime = 0f;

        // 初始化状态索引和状态机
        for (int i = 0; i < states.Count; i++) {
            statesIndex[states[i].state] = i;
            states[i].SetController(this);
            states[i].SetEnemy(enemy);
        }

        //执行进入当前状态时的逻辑
        states[statesIndex[currentState]].OnEnter();
    }

    /// <summary>
    /// 执行状态控制机的更新逻辑
    /// </summary>
    /// <param name="deltaTime"></param>
    public void OnUpdate(float deltaTime) {
        states[statesIndex[currentState]].OnUpdate();
        currentStateTime += deltaTime;
    }
}
