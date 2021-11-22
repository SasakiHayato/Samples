using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorAI;

public class ConditionA : IConditional
{
    bool _check = false;

    public bool Check()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _check = true;
        }
        else
        {
            _check = false;
        }
        return _check;
    }
}
