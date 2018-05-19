using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float speed = 10f;

    private float health;
    public float startHealth = 100;
    private bool isDead = false;

    public int value = 5;
    public GameObject DeathEffect;
    private Transform target;
    private int waveWayPointIndex = 0;

    [Header("Stuff")]
    public Image healthBar;

    void Start()
    {
        health = startHealth;
        target = Waypoints.waypoint[0];
    }

    public void TakeDamage(float amount)
    {

        health -= amount;

        healthBar.fillAmount = health / startHealth;
        if (health <= 0 && !isDead)
        {
            Die();
        }
        

    }
    void Die()
    {
        PlayerStat.Money += value;

        GameObject effect = (GameObject)Instantiate(DeathEffect,transform.position, Quaternion.identity);
        Destroy(effect, 3f);
        isDead = true;
        Destroy(gameObject);
    }
    void Update()
    {
        
        Vector3 diraction = target.position - transform.position; //от одной позиции мы поворачиваемся к другой 
        transform.Translate(diraction.normalized * speed * Time.deltaTime,Space.World); // переводим со скоростью

        if (Vector3.Distance(transform.position,target.position)<= 0.4f) //время поворота обьекта enemy
        {
            NextWayPoint();
        }
    }

    void NextWayPoint()
    {
        if(waveWayPointIndex >= Waypoints.waypoint.Length - 1 )
        {
            EndPath();
            return;
        }
        waveWayPointIndex++;
        target = Waypoints.waypoint[waveWayPointIndex];
    }
    void EndPath()
    {
        PlayerStat.Lives--;
        Destroy(gameObject);
    }
}
