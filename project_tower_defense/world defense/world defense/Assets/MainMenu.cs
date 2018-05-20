using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public int levelLoad = 2;
	public void Play()
    {
        SceneManager.LoadScene(levelLoad);
    }
    public void Quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
