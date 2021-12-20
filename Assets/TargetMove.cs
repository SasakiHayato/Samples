using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMove : MonoBehaviour
{
    enum Type
    {
        Wide,
        Circle,
    }

    [SerializeField] Type _type;

    float _time;

    void Update()
    {
        _time += Time.deltaTime;
        Vector3 set = Vector3.zero;
        switch (_type)
        {
            case Type.Wide:
                set = new Vector3(Mathf.Cos(_time), 0, 0);
                break;
            case Type.Circle:
                set = new Vector3(Mathf.Cos(_time), 0, Mathf.Sin(_time));
                break;
        }
        transform.Translate(set.normalized / 48, Space.World);
    }
}
