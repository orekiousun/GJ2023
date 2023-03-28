using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;
using TarodevController;

public class CharacterManager : LogicModuleBase, ICharacterManager {
    private PlayerController player;
    public PlayerController Player => player;

    #region Unity Callback

    public override void Awake() {
        
    }

    public override void Init() {
        MessageManager.Instance.Get<SceneMessage>().RegisterHandler(SceneMessage.NewSceneLoaded, (sender, args) => {
            if(player == null) {
                player = Object.FindObjectOfType<PlayerController>();
                if(player == null || player.transform.parent.name == "ObjectPool")
                    player = ResourceManager.Instance.Instantiate("Prefabs/Character/Player").GetComponent<PlayerController>();
            }
        });
    }

    public override void Update() {
        
    }

    public override void FixedUpdate() {
        
    }

    public override void OnDestroy() {
        
    }

    #endregion
}
