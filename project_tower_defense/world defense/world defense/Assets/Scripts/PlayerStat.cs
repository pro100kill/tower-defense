using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour {

    public static int Money;
    public int startMoney = 40;

    public static int Lives;
    public int startLive = 15;

    public static int Rounds;


    void Start()
    {
        Money = startMoney;
        Lives = startLive;
        Rounds = 0;
    }
}
