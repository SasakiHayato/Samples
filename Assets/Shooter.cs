using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] Bullet _bullet;
    [SerializeField] float _coolTime;
    [SerializeField] float _speed;
    float _time;

    GameObject _target;
    Vector3 _before = Vector3.zero;
    Deviation _deviation;

    void Start()
    {
        _deviation = new Deviation();
        _target = GameObject.Find("Target");
    }

    void Update()
    {
        _time += Time.deltaTime;
        if (_time > _coolTime)
        {
            Vector3 tPos = _target.transform.position;
            Vector3 set = _deviation.DeviationDir(tPos, transform.position, _before, _speed);
            _bullet.Shot(set, transform, _speed);
            _time = 0;
        }

        _before = _target.transform.position;
    }
}
