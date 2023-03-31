using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;
using UnityEngine.SceneManagement;

public enum SceneMessage {
    WillUnload,
    NewSceneLoaded,
}

public class GameSceneManager : LogicModuleBase, IGameSceneManager {
    private string lastScene;
    public string LastScene => lastScene;

    private string currentScene;
    public string CurrentScene => currentScene;

    public void ChangeScene(string newScene) {
        SceneUnload();
        lastScene = currentScene;
        if(currentScene != "NullScene")
            SceneManager.UnloadSceneAsync(LastScene);
        currentScene = newScene;
        SceneManager.LoadScene(currentScene, LoadSceneMode.Additive);
    }

    private void SceneUnload() {
        MessageManager.Instance.Get<SceneMessage>().DispatchMessage(SceneMessage.WillUnload, this);
    }

    private void SceneLoaded(Scene scene, LoadSceneMode mode) {
        MessageManager.Instance.Get<SceneMessage>().DispatchMessage(SceneMessage.NewSceneLoaded, this);
        UIManager.Instance.Open(NameList.UI.TipUI.ToString(), args: currentScene);
    }


#region Unity Callback

    public override void Awake() {

    }

    public override void Init() {
        SceneManager.sceneLoaded += SceneLoaded;
        currentScene = "NullScene";
    }

    public override void Update() {
        
    }

    public override void FixedUpdate() {
        
    }

    public override void OnDestroy() {
        
    }

#endregion
}
