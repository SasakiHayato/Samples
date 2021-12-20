using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject _bullet;

    public void Shot(Vector3 dir, Transform parent, float speed = 10)
    {
        GameObject obj = Instantiate(_bullet);
        obj.transform.position = parent.position;
        obj.GetComponent<Rigidbody>().AddForce(dir * speed, ForceMode.Impulse);
    }
}
