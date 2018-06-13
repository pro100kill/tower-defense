
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour {

    public float panSpeed = 30f;
	private Vector3 camPosition;
    public float panBorder = 10f;
    public float scrollspeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;
	// Update is called once per frame
	void Update () {
	    camPosition = transform.position;
        camPosition.x = Mathf.Clamp(camPosition.x, -50, 50);
        camPosition.z = Mathf.Clamp(camPosition.z, -50, 50);
        transform.position = camPosition;
        if (GameManager1.gameEnd)
        {
            this.enabled = false;
            return;
        }
		if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 posit = transform.position;
        posit.y -= scroll *1000* scrollspeed * Time.deltaTime;
        posit.y = Mathf.Clamp(posit.y, minY, maxY);
        transform.position = posit;
	
    }
	
}
