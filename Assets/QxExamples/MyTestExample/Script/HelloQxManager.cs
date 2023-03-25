using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;

public interface IHelloQxManager
{
    void HelloQXFunction();
}

public class HelloQxManager : LogicModuleBase, IHelloQxManager
{
    void IHelloQxManager.HelloQXFunction()
    {
        Debug.Log("HelloQXFunction executed");
    }
}
