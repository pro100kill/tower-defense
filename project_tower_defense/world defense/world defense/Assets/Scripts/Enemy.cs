using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10f;

    private Transform target;
    private int waveWayPointIndex = 0;

    void Start()
    {
        target = Waypoints.waypoint[0];
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
            Destroy(gameObject);
            return;
        }
        waveWayPointIndex++;
        target = Waypoints.waypoint[waveWayPointIndex];
    }
}
