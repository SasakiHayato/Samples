using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorAI;

public class ActionB : IAction
{
    bool _isEnd = false;

    public void Execute()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("ActionB");
            _isEnd = true;
        }
        
    }

    public bool End()
    {
        return _isEnd;
    }

    public bool Reset { set { _isEnd = value; } }
}
