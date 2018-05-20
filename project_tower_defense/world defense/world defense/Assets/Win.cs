using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Win : MonoBehaviour {

    public Text roundsText;

    void OnEnable()
    {
        roundsText.text = PlayerStat.Rounds.ToString();
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
