using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorAI;

public class TreeUser : MonoBehaviour, IBehavior
{
    [SerializeField] BehaviorTree _tree;

    void Update() => _tree.Repeater(this);
    public void Call(IAction a) => a.Execute();
}
