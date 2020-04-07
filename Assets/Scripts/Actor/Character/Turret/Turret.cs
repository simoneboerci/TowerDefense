using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("ATTRIBUTI")]
    public float speed = 10f;
    public float range = 10f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    // public float bulletspeed
    // public float damage

    [Header("Unity")]
    public GameObject bulletPrefab;
    public Transform target;
    public Transform firePoint;
    
    public string enemyTag = "Enemy";

    Vector3 lastKnowPosition = Vector3.zero;
    Quaternion lookAtRotation;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void Update()
    {
        if (target == null)
            return;
        FollowTarget();
        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;


    }

    #region Shoot
    void Shoot()
    {
        GameObject bulletGO = (GameObject) Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }
    #endregion

    #region Tracking Update
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }else
        {
            target = null;
        }
    }
    #endregion

    #region Follow Target
    void FollowTarget()
    {
        if (target)
        {
            if (lastKnowPosition != target.transform.position)
            {
                lastKnowPosition = target.transform.position;
                lookAtRotation = Quaternion.LookRotation(lastKnowPosition - transform.position);
            }
            if (transform.rotation != lookAtRotation)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, lookAtRotation, speed * Time.deltaTime);
            }
        }

    }
        #endregion

    #region Gizmos
        void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, range);
        }
   
        #endregion  
}
