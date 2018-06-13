using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class trigger : MonoBehaviour {
    private bool trig = false;
    public GameObject parsys;
	// Update is called once per frame
	
    void OnTriggerEnter(Collider other)
    {
        trig = true;
        if (other.tag == "Enemy")
        {
            Instantiate(parsys,transform.position,transform.rotation);
        }
    }

    void OnTriggerExit(Collider other)
    {
        trig = false;
        if (other.tag == "Enemy")
        {
            Destroy(parsys);
        }
    }
}
