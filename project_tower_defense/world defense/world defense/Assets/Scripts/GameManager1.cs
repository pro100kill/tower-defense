using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour {

    public static bool gameEnd;

    public GameObject gameOverUI;
	// Update is called once per frame
    void Start()
    {
        gameEnd = false;
    }
	void Update () {

        if (gameEnd)
            return;
        if(Input.GetKeyDown("e"))
        {
            EndGame();
        }
		if(PlayerStat.Lives <= 0)
        {
            EndGame();
        }
	}
    void EndGame()
    {
        gameEnd = true;
        gameOverUI.SetActive(true);
        //Debug.Log("Game Over");
    }
}
