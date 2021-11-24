﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool<T> where T : Object
{
    List<GameObject> _targetList = new List<GameObject>();
    List<GameObject> _deleteList = new List<GameObject>();

    int _count;
    GameObject _setTarget;
    
    public void Create(GameObject set)
    {
        _setTarget = set;
        for (int i = 0; i < 10; i++)
        {
            _count++;
            GameObject obj = Object.Instantiate(set);
            obj.name = $"Pool {_count}";
            _targetList.Add(obj);
            obj.SetActive(false);
        }
    }

    public GameObject Use()
    {
        bool check = false;
        GameObject target = default;
        foreach (GameObject obj in _targetList)
        {
            bool active = obj.activeSelf;
            if (!active)
            {
                check = true;
                obj.SetActive(true);
                target = obj;
                break;
            }
        }
        if (!check)
        {
            GameObject obj = Object.Instantiate(_setTarget);
            _count++;
            obj.name = $"Pool {_count}";
            _targetList.Add(obj);
            target = obj;
        }

        _deleteList.Add(target);
        return target;
    }

    public void Delete()
    {
        if (_deleteList.Count <= 0) return;

        _deleteList.First().SetActive(false);
        _deleteList.Remove(_deleteList.First());
    }
}
