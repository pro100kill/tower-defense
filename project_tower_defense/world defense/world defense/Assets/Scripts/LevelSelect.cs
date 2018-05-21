using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {
     public GameObject level;
     public void Select(int levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
