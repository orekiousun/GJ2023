using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;
using TarodevController;

public class CharacterManager : LogicModuleBase, ICharacterManager {
    private List<EnemyBase> enemies = new List<EnemyBase>();
    // 用于存储当前场景中的所有敌人对象
    private PlayerController player;
    public PlayerController Player => player;
    // 用于保存玩家对象

#region Unity Callback

    public override void Awake() {
        
    }

    public override void Init() {
        // 新场景加载时，获取到玩家对象
        MessageManager.Instance.Get<SceneMessage>().RegisterHandler(SceneMessage.NewSceneLoaded, (sender, args) => {
            if(player == null) {
                player = Object.FindObjectOfType<PlayerController>();
                if(player == null || player.transform.parent.name == "ObjectPool")
                    player = ResourceManager.Instance.Instantiate("Prefabs/Character/Player").GetComponent<PlayerController>();
            }
        });
    }

    public override void Update() {
        foreach (var item in enemies) {
            item.OnUpdate();
        }

    }

    public override void FixedUpdate() {
        
    }

    public override void OnDestroy() {
        
    }

#endregion
}
