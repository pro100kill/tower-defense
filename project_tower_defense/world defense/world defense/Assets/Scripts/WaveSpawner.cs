using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WaveSpawner : MonoBehaviour {

    public static int EnemyAlive = 0;
    //public Transform enemyPrefab;
    public Wave[] waves;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int waveNumber = 0;
    public Text waveCountdownText;
    public GameManager1 gameMamager1;
    void Update()
    {
        if(EnemyAlive > 0)
        {
            return;
        }
        if (waveNumber == waves.Length)
        {

            gameMamager1.LevelWon();

            // SceneManager.LoadScene(3);
            this.enabled = false;

        }
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave()); // должно работать паралельно в течении опр. времени
            countdown = timeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime;

       // countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        //waveCountdownText.text = string.Format("{ 0:00.00}", countdown);
        waveCountdownText.text = Mathf.Round(countdown).ToString();

    }


    IEnumerator SpawnWave() // исп. паралельно в течении некоторого времени
    {

        
        PlayerStat.Rounds++;
        Wave wave = waves[waveNumber];
         EnemyAlive = wave.count;
        //EnemyAlive = wave.count;
        for (int i = 0; i < wave.count; i++)
        {
            spawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate); //продолжить через время 
        }
        
        waveNumber++;
        
        

        //Debug.Log("Wave Incoming!");
    }
    void spawnEnemy(GameObject enemy)
    {
        
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        //EnemyAlive++;
    }
}
