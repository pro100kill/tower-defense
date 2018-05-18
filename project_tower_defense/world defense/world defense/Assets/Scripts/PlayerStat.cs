using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour {

    public static int Money;
    public int startMoney = 40;

    public static int Lives;
    public int startLive = 15;
    void Start()
    {
        Money = startMoney;
        Lives = startLive;
    }
}
