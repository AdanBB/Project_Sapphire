using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletFire : MonoBehaviour
{
    public float range;

    public float fireTime;

    private float _firetime;

    void Start()
    {
        _firetime = fireTime;
    }

    void Update()
    {

        Debug.DrawRay(transform.position, transform.forward * 50, Color.yellow);
        
        if (_firetime != 0)
        {
            _firetime--;
        }
        else if (_firetime == 0 && Input.GetMouseButtonDown(0))
        {
            Fire();
            _firetime = fireTime;
        }
    }

    void Fire()
    {
        GameObject obj = PoolingObjectScript.current.GetPooledObject();

        if (obj == null) return;

        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);

    }
}
