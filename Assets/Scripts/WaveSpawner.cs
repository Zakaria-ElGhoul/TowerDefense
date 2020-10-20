using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefeb;
    public Transform SpawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 3f;
    private int WaveNumber = 1000;
    public TMP_Text countDownText;
    public TMP_Text waveIndex;

    void Start()
    {
        countDownText.text = countdown.ToString();
        waveIndex.text = "Wave: " + waveIndex.ToString();
    }
    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        countDownText.text = "Next wave: " + TimeSpan.FromSeconds(countdown).ToString("s\\.f");
        waveIndex.text = "Wave: " + WaveNumber.ToString();
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < WaveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(.75f);
        }
        timeBetweenWaves += 5;
        WaveNumber++;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefeb, SpawnPoint.position, SpawnPoint.rotation);
    }


}