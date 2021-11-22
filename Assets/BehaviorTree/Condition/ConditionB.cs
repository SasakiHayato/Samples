using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorAI;

public class ConditionB : IConditional
{
    bool _check = false;

    public bool Check()
    {
        if (Input.GetKey(KeyCode.B))
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
