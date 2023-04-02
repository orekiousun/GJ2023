using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NameList;
using QxFramework.Core;

public class EnemyBase : MonoBehaviour {
    public Transform Target;
    private EnemyStateController stateController;
    private Rigidbody2D rb2D;
    private Collider2D col2D;
    private Animator animator;


    // 获取目标相关参数
    public static LayerMask targetLayer = Utils.GetMask(Layer.Player);
    private float searchAngle;                  // 检测的角度
    [SerializeField] private float searchAngleThreshold = 0.5f;   // 检测角度阈值
    [SerializeField] private bool searchDown = false;             // 是否为飞行怪物
    [SerializeField] private float detectDistance = 6;            // 检测距离
    [SerializeField] private float loseTargetDistance = 9;        // 丢失目标的距离
    /// <summary>
    /// 检测目标
    /// </summary>
    public void CheckTarget() {
        Vector2 searchRight = new Vector2(1, searchAngle);
        Vector2 searchLeft = new Vector2(-1, searchAngle);

        // 进行角度的迭代
        if (searchAngle > searchAngleThreshold && !searchDown)
            searchAngle = 0;
        else {
            if (searchAngle > 0 && searchDown)
                searchAngle = -searchAngleThreshold;
            else
                searchAngle += 0.02f;
        }

        // 如果当前没有目标，就检测能否找到目标
        if (Target == null) {
            RaycastHit2D horizontal;
            if (isFacingLeft)
                horizontal = Utils.Raycast(col2D.bounds.max - new Vector3(-0.5f, col2D.bounds.extents.y, 0), searchLeft, detectDistance, EnemyBase.targetLayer, Color.white);
            else
                horizontal = Utils.Raycast(col2D.bounds.min + new Vector3(-0.5f, col2D.bounds.extents.y, 0), searchRight, detectDistance, EnemyBase.targetLayer, Color.white);
            if (horizontal)
                Target = horizontal.transform;
        }

        // 如果当前有目标，就检测目标是否脱离有效范围
        else {
            if (((Vector2)Target.position - (Vector2)transform.position).sqrMagnitude > loseTargetDistance * loseTargetDistance) {
                Target = null;
            }
        }
    }

    // 朝向相关参数
    public bool isFacingLeft;   // 是否朝向左边
    /// <summary>
    /// 改变朝向
    /// </summary>
    public void ChangeFacing(float x) {
        Vector3 faceLeft = new Vector3(1, 1, 1);
        Vector3 faceRight = new Vector3(-1, 1, 1);

        // 默认情况下为朝向左边
        if(x <= transform.position.x && !isFacingLeft) {
            transform.localScale = faceLeft;
            isFacingLeft = true;
        }
        else if(x > transform.position.x && isFacingLeft) {
            transform.localScale = faceRight;
            isFacingLeft = false;
        }
    }

    // 改变速度相关参数
    [SerializeField] private float speedXThreshold = 3f;   // 最大加速度阈值
    /// <summary>
    /// 改变敌人的速度
    /// </summary>
    /// <param name="accelerateSpeed">加速度，当加到最大速度时停止加速</param>
    public void ChangeSpeed(float accelerateSpeed, bool stop) {
        // 如果需要敌人停下，则直接设置速度为0
        if(stop) {
            rb2D.velocity = Vector2.zero;
            return;
        }

        // 否则，进行加速度，直到加速到最大阈值
        if(isFacingLeft) {
            if(rb2D.velocity.x > 0)
                rb2D.velocity = Vector2.zero;
            else if(rb2D.velocity.x > -speedXThreshold)
                rb2D.velocity -= Vector2.left * accelerateSpeed;
        }
        else {
            if(rb2D.velocity.x < 0)
                rb2D.velocity = Vector2.zero;
            else if(rb2D.velocity.x < speedXThreshold)
                rb2D.velocity += Vector2.right * accelerateSpeed;
        }
    }
    /// <summary>
    /// 直接修改速度为某一值
    /// </summary>
    /// <param name="newSpeed"></param>
    public void ChangeSpeed(float newSpeed) {
        rb2D.velocity = new Vector2(Mathf.Clamp(newSpeed, -speedXThreshold, speedXThreshold), rb2D.velocity.y);

    }

#region Unity Callback

    /// <summary>
    /// 初始化敌人，在敌人生成时调用
    /// </summary>
    public virtual void InitEnemy() {
        stateController = GetComponent<EnemyStateController>();
        rb2D = this.GetComponent<Rigidbody2D>();
        col2D = GetComponent<Collider2D>();
        animator = GetComponentInChildren<Animator>();
        stateController.InitController();
        isFacingLeft = true;
    }

    /// <summary>
    /// 在敌人生命周期内，执行敌人的更新逻辑
    /// </summary>
    public virtual void OnUpdate() {
        stateController.OnUpdate(Time.deltaTime);
        CheckTarget();
    }

    private void Awake() {
        InitEnemy();
    }

    private void Update() {
        OnUpdate();
    }

#endregion
}
