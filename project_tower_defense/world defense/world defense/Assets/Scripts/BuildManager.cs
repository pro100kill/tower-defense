using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;
    private BlueTurretPrint turretBuilt;

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
    public GameObject anotherTurretPrefaab;

    public bool CanBuild { get { return turretBuilt != null; } }
    public bool HasMoney { get { return PlayerStat.Money >= turretBuilt.cost; } }

    public void BuildTurretOn(node1 node)
    {
        if(PlayerStat.Money < turretBuilt.cost)
        {
            Debug.Log("Нет денег");
            return;
        }

        PlayerStat.Money -= turretBuilt.cost;
       GameObject turret = (GameObject) Instantiate(turretBuilt.prefab, node.GetBuildPosition(),Quaternion.identity);
        node.turret = turret;

        Debug.Log("Турель построена "+ PlayerStat.Money);
    }

    public void SetTurretBuild (BlueTurretPrint turret)
    {
        turretBuilt = turret;
    }
}
