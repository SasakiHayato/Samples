using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorAI;

public class ConditionC : IConditional
{
    bool _check = false;
    public GameObject Target { private get; set; }

    public bool Check()
    {
        if (Input.GetKey(KeyCode.C))
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
