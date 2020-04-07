using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 10f;

    public void Seek(Transform _target)
    {
        target = _target;
    }
    
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distance = speed + Time.deltaTime;
        if(dir.magnitude <= distance)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distance);
    }

    void HitTarget()
    {
        Debug.Log("gesu pls");
        Destroy(gameObject);
        return;
    }
}
