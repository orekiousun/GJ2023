using QxFramework.Core;
using System;
using UnityEngine;
using UnityEngine.UI;

public class HelloQXUI : UIBase
{
    [ChildValueBind("CloseBtn", nameof(Button.onClick))]
    Action OnCloseButton;

    [ChildValueBind("DisappearBtn", nameof(Button.onClick))]
    Action OnDisappearButton;

    [ChildValueBind("FunctionBtn", nameof(Button.onClick))]
    Action OnFunctionButton;

    [ChildValueBind("LoadPrefabBtn", nameof(Button.onClick))]
    Action OnLoadPrefabButton;
    
    [ChildValueBind("DispatchBtn", nameof(Button.onClick))]
    Action OnDispatchButton;

    [ChildValueBind("AddSceneBtn", nameof(Button.onClick))]
    Action OnAddSceneButton;

    [ChildValueBind("SavaDataBtn", nameof(Button.onClick))]
    Action OnSaveDataButton;

    [ChildValueBind("LoadBtn", nameof(Button.onClick))]
    Action OnLoadButton;

    [ChildValueBind("ChangeDataBtn", nameof(Button.onClick))]
    Action OnChangeDataButton;

    public override void OnDisplay(object args)
    {
        base.OnDisplay(args);
        OnCloseButton = CloseButton;
        OnCloseButton += ChangeToSecondProcedure;
        OnDisappearButton = DisappearButton;
        OnFunctionButton = FunctionButton;
        OnLoadPrefabButton = LoadPrefabButton;
        OnDispatchButton = DispatchButton;
        OnAddSceneButton = AddSceneButton;
        OnSaveDataButton = SaveData;
        OnLoadButton = LoadButton;
        OnChangeDataButton = ChangeButton;
    }

    private void DisappearButton()
    {
        Find("DisappearBtn").SetActive(false);
    }

    private void CloseButton()
    {
        Debug.Log("CloseButton");
    }

    private void ChangeToSecondProcedure()
    {
        Debug.Log("ChangeProcedure");
        ProcedureManager.Instance.ChangeTo("SecondProcedure", "Send Args");
    }

    private void FunctionButton()
    {
        GameMgr.Get<IHelloQxManager>().HelloQXFunction();
    }

    private void LoadPrefabButton()
    {
        ResourceManager.Instance.Instantiate("HelloQXFolder/HelloQXPrefab");
    }

    private void DispatchButton()
    {
        MessageManager.Instance.Get<HelloQXMessageType>().DispatchMessage(HelloQXMessageType.First, this, new HelloQxEventArgs("Qx", "The Best Development Framework"));
    }

    private void AddSceneButton()
    {
        LevelManager.Instance.OpenLevel("QxLevel_2", OnChangeLevel);
    }

    private void OnChangeLevel(string obj)
    {
        Debug.Log(obj);
    }

    private void SaveData()
    {
        QXData.Instance.SaveToFile("QxDataSave");
    }

    private void LoadButton()
    {
        if (GameMgr.Get<IHelloQxDataManager>().Load())
        {
            Get<Text>("DisplayText").text = GameMgr.Get<IHelloQxDataManager>().DisplayStr();
        }
        else
        {
            Get<Text>("DisplayText").text = "�޴浵";
        }
    }


    private void ChangeButton()
    {
        GameMgr.Get<IHelloQxDataManager>().ChangeData("After ChangeData");
        QXData.Instance.SaveToFile("QxDataSave");
    }

    public void DeleteSave()
    {
        QXData.Instance.DeleteFile("QXDataSave");
    }
}
