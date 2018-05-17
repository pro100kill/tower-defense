using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour {

    public static int Money;
    public int startMoney = 40;

    void Start()
    {
        Money = startMoney;
    }
}
