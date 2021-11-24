using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    [SerializeField] GameObject _poolObj;
    ObjectPool<GameObject> _pool = new ObjectPool<GameObject>();

    void Start()
    {
        
        _pool.Create(_poolObj);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _pool.Use();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _pool.Delete();
        }
    }
}
