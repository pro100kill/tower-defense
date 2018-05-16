using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tsrtt : MonoBehaviour
{

    public Color hoverColor;
    public Vector3 positionOffset;
    private GameObject turret;
    private Renderer rend;
    private Color startColor;


    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void onMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("нельзя стоить там");
            return;
        }
        GameObject turretBuilt = BuildManager.instance.GetTurretBuilt();
        turret = (GameObject)Instantiate(turretBuilt, transform.position + positionOffset, transform.rotation);
    }
    void onMouseEnter()
    {
        rend.material.color = hoverColor;
    }
    void onMouseExit()
    {
        rend.material.color = startColor;
    }
}

