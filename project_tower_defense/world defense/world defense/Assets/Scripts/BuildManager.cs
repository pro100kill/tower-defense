using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;
    private GameObject turretBuilt;

    void Awake()
    {
        if(instance != null)
        {
            Debug.Log("больше чем один BuildManager на сцене");
            return;
        }
        instance = this;
    }
    public GameObject standartTurretPrefab;

    void Start()
    {
        turretBuilt = standartTurretPrefab;
    }

    public GameObject GetTurretBuilt()
    {
        return turretBuilt;
    }
}
