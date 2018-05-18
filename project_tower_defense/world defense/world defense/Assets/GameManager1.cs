using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour {

    private bool gameEnd = false;
	// Update is called once per frame
	void Update () {

        if (gameEnd)
            return;
		if(PlayerStat.Lives <= 0)
        {
            EndGame();
        }
	}
    void EndGame()
    {
        gameEnd = true;
        Debug.Log("Game Over");
    }
}
