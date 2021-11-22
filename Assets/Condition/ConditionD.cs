using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorAI;

public class ConditionD : IConditional
{
    bool _check = false;

    public bool Check()
    {
        if (Input.GetKey(KeyCode.D))
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
