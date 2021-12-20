using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] Bullet _bullet;
    [SerializeField] float _coolTime;
    float _time;

    Deviation _deviation = new Deviation();

    GameObject _target;
    Vector3 _before = Vector3.zero;

    void Start()
    {
        _target = GameObject.Find("Target");
    }

    void Update()
    {
        _time += Time.deltaTime;
        if (_time > _coolTime)
        {
            _deviation.Predict(transform, _target.transform, _before);
            _bullet.Shot(_deviation.GetDir, transform);
            _time = 0;
        }

        _before = _target.transform.position;
    }
}
