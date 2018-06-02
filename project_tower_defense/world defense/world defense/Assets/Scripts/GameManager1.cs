using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager1 : MonoBehaviour {

    public static bool gameEnd;
   
    public GameObject gameOverUI;
    public GameObject WIN;
    //public SceneFader sceneFader;
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
    public void EndGame()
    {
        gameEnd = true;
        gameOverUI.SetActive(true);
        //Debug.Log("Game Over");
    }
    public void LevelWon()
    {
        gameEnd = true;
        WIN.SetActive(true);
        //sceneFader.FadeTo(3);

        //Debug.Log("WON");
       // SceneManager.LoadScene(3);
    }
   
}
