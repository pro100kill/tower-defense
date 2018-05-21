using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public Text roundsText;
    public SceneFader sceneFader;
    void OnEnable()
    {
        roundsText.text = PlayerStat.Rounds.ToString();
    }

    public void Retry()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        sceneFader.FadeTo(SceneManager.GetActiveScene().buildIndex);

    }
    public void Menu()
    {
        Debug.Log("Menu");
        sceneFader.FadeTo(0);
        //SceneManager.LoadScene(0);
    }
    
}
