using QxFramework.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using QxFramework;

/// <summary>
/// 游戏管理器，用于管理之前由MonoSingleton所有逻辑
/// </summary>
public class GameMgr : MonoSingleton<GameMgr> {
    /// <summary>
    /// 所有模块列表
    /// </summary>
    private readonly List<LogicModuleBase> _modules = new List<LogicModuleBase>();

    [SerializeField] private GameSceneManager sceneManager;
    [SerializeField] private CharacterManager characterManager;
    [SerializeField] private EventManager eventManager;

    public static IGameSceneManager SceneMgr{get; private set;}
    public static ICharacterManager CharacterMgr {get; private set;}
    public static IEventManager EventMgr {get; private set;}

    /// <summary>
    /// 初始化所有模块
    /// </summary>
    public void InitModules() {
        _modules.Clear();
        characterManager = new CharacterManager();
        sceneManager = new GameSceneManager();
        eventManager = new EventManager();

        SceneMgr = Add<IGameSceneManager>(sceneManager);
        CharacterMgr = Add<ICharacterManager>(characterManager);
        EventMgr = Add<IEventManager>(eventManager);

        foreach (var module in _modules) {
            module.Awake();
        }
    }

    /// <summary>
    /// 将模块加入_modules模块列表中
    /// </summary>
    private T Add<T>(LogicModuleBase module) {
        _modules.Add(module);
        module.Init();
        return (T)(object)module;
    }

#region Unity Callback
    private void Init() {
        foreach (var module in _modules) {
            module.Init();
        }
    }

    private void Update() {
        foreach (var module in _modules) {
            module.Update();
        }
    }

    private void FixedUpdate() {
        foreach (var module in _modules) {
            module.FixedUpdate();
        }
    }

    private void OnDestroy() {
        foreach (var module in _modules) {
            module.OnDestroy();
        }
        _modules.Clear();

        sceneManager = null;
        characterManager = null;

        SceneMgr = null;
        CharacterMgr = null;
    }

#endregion
}