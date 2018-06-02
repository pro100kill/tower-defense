using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour {


    private Transform target;
    private Enemy enemyTarget;

    [Header("Общие")]
    public float range = 15f;
    

    [Header("Use bullets")]
    public GameObject bulletPrefabs;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    [Header("Use Laser")]
    public int damageOverTime = 30;
    public bool useLaser = false;
    public LineRenderer lineRenderer;
    public AudioSource audio;
    public AudioClip audioClip;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnspeed = 10f;

    
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
            enemyTarget= nearEnemy.GetComponent<Enemy>();
        } else
        {
            target = null;
        }

    }
	// Update is called once per frame
	void Update () {
        if (target == null)
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                    lineRenderer.enabled = false;
            }
            return;
        }
            

        LookOnTarget();

        if (useLaser)
        {
            Laser();
        }else
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }


        
    }
    void LookOnTarget()
    {
        // взятие цели
        Vector3 diraction = target.position - transform.position;
        Quaternion lookRotate = Quaternion.LookRotation(diraction);   // исп. для записи вращения
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotate, Time.deltaTime * turnspeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
    void Laser()
    {
        enemyTarget.TakeDamage(damageOverTime*Time.deltaTime);
        audio.PlayOneShot(audioClip);
        if (!lineRenderer.enabled)
            lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

    }
    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefabs, firePoint.position, firePoint.rotation); //создание обьектов 
        bullet bullet1 = bulletGO.GetComponent<bullet>();
        audio.PlayOneShot(audioClip);
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
