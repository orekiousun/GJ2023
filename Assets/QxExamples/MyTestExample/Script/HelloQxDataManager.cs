using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;

public interface IHelloQxDataManager
{
    public HelloQxGameData HelloQXGameData { get; }
    public string DisplayStr();
    public bool Load();
    public void ChangeData(string value);
}

public class HelloQxDataManager : LogicModuleBase, IHelloQxDataManager
{
    private HelloQxGameData _helloQXData;
    public HelloQxGameData HelloQXGameData
    {
        get
        {
            _helloQXData = QXData.Instance.Get<HelloQxGameData>();
            return _helloQXData;
        }
    }

    public override void Init()
    {
        base.Init();
        Debug.Log("HelloQxDataManager Init");
        if(!RegisterData(out _helloQXData))
        {
            HelloQXGameData.QXString = "";
            HelloQXGameData.QXID = 0;
            HelloQXGameData.QXBool = false;
        }
    }

    public string DisplayStr()
    {
        string value = HelloQXGameData.QXString + HelloQXGameData.QXID + HelloQXGameData.QXBool;
        return value;
    }

    public bool Load()
    {
        return QXData.Instance.LoadFromFile("QXDataSave");
    }

    public void ChangeData(string value)
    {
        HelloQXGameData.QXString = value;
    }
}
