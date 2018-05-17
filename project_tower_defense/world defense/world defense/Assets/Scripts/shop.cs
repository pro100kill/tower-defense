using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour {
    public BlueTurretPrint standartTurret;
    public BlueTurretPrint anotherTurret;

    BuildManager buildManager;
    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void BuyStandartTurrel()
    {
        Debug.Log("Standart turrret");
        buildManager.SetTurretBuild(standartTurret);
    }
    public void BuyAnotherTurret()
    {
        Debug.Log("Another turrret");
        buildManager.SetTurretBuild(anotherTurret);
    }
}
