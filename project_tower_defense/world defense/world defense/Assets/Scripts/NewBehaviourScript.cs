using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {

    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int waveNumber = 0;
    public Text waveCountdownText;

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;

       // countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        //waveCountdownText.text = string.Format("{ 0:00.00}", countdown);
        waveCountdownText.text = Mathf.Round(countdown).ToString();

    }


    IEnumerator SpawnWave() // исп. паралельно в течении некоторого времени
    {

        waveNumber++;
        PlayerStat.Rounds++;
        for (int i = 0; i < waveNumber; i++)
        {
            spawnEnemy();
            yield return new WaitForSeconds(0.5f); //продолжить через время 
        }
        
        //Debug.Log("Wave Incoming!");
    }
    void spawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
