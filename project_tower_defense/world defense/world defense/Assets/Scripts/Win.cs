using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Win : MonoBehaviour {

    public Text roundsText;
    public SceneFader sceneFader;

    void OnEnable()
    {
        roundsText.text = PlayerStat.Rounds.ToString();
    }
    public void Continue()
    {
        sceneFader.FadeTo(3);

    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
        Debug.Log("Menu");
        SceneManager.LoadScene(0);
    }
}
