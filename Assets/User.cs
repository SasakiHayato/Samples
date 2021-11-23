using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Pool;

public class User : MonoBehaviour
{
    ObjectPool<Bullet> _pool = new ObjectPool<Bullet>();
    
    void Start()
    {
        _pool.Use();
    }
}
