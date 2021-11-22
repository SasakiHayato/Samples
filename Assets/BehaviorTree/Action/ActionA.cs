using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorAI;

public class ActionA : IAction
{
    bool _isEnd = false;

    public void Execute()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("ActionA");
            _isEnd = true;
        }
    }

    public bool End()
    {
        return _isEnd;
    }

    public bool Reset { set { _isEnd = value; } }
}
