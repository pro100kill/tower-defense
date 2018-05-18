using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    private Transform target;
    public GameObject impactEffect;
    public float speed  = 70f;
    public int damage = 50;
    public void Seek(Transform itarget)
    {
        target = itarget;

    }
    

    
	
	// Update is called once per frame
	void Update () {
		if (target == null)
        {
            Destroy(gameObject);
                return;
        }
        Vector3 diraction = target.position - transform.position;
        float distanceframe = speed *Time.deltaTime;
        if(diraction.magnitude <= distanceframe)
        {
            HiTarget();
            return;
        }
        transform.Translate(diraction.normalized * distanceframe, Space.World);
        transform.LookAt(target);
	}
    void HiTarget()
    {
        GameObject effect = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effect, 1f);

        Damage(target);
       Destroy(gameObject);
    }
    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        if (e != null)
        {
            e.TakeDamage(damage);
        }
            
        
        //Destroy(enemy.gameObject);
    }
}
