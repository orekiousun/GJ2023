using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HelloQxEventArgs : EventArgs
{
    public string name;
    public string description;

    public HelloQxEventArgs(string _name, string _description)
    {
        this.name = _name;
        this.description = _description;
    }
}
