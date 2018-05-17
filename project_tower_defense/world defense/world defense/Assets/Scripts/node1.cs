using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class node1 : MonoBehaviour
{

    public Color hoverColor;
    public Color NotEnoughMoneyColor;
    public Vector3 positionOffset;
    [Header("Optional")]
    public GameObject turret;
    private Renderer rend;
    private Color startColor;

    BuildManager builtmanager;
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        builtmanager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!builtmanager.CanBuild)
            return;
        if (turret != null)
        {
            Debug.Log("нельзя стоить там");
            return;
        }
        builtmanager.BuildTurretOn(this);


    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!builtmanager.CanBuild)
            return;

        if(builtmanager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = NotEnoughMoneyColor;
        }
        
    }
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
