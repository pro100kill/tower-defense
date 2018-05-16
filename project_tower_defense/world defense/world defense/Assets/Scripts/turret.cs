using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour {


    private Transform target;

    [Header("Attributes")]
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnspeed = 10f;

    public GameObject bulletPrefabs;
    public Transform firePoint;

   
	// Use this for initialization
	void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}
	
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortDistance = Mathf.Infinity;
        GameObject nearEnemy = null;
        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortDistance)
            {
                shortDistance = distanceToEnemy;
                nearEnemy = enemy;
            }
        }
        if(nearEnemy != null && shortDistance <= range)
        {
            target = nearEnemy.transform;
        } else
        {
            target = null;
        }

    }
	// Update is called once per frame
	void Update () {
        if (target == null)
            return;
        // взятие цели
        Vector3 diraction = target.position - transform.position;
        Quaternion lookRotate = Quaternion.LookRotation(diraction);   // исп. для записи вращения
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotate, Time.deltaTime * turnspeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f,rotation.y,0f);

        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }
    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefabs, firePoint.position, firePoint.rotation); //создание обьектов 
        bullet bullet1 = bulletGO.GetComponent<bullet>();
        if (bullet1 != null)
        {
            bullet1.Seek(target);
        }
    }
    void onDrawGizmoSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
