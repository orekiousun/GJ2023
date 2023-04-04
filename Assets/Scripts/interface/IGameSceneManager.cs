using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameSceneManager  {
    
    public GameObject CurrentSceneAnchorPoint { get; }
    string LastScene {get;}
    string CurrentScene {get;}
    void ChangeScene(string newScene);
}
