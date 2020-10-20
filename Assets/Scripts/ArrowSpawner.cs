using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ArrowSpawner : MonoBehaviour
{
    public Transform ArrowPrefeb;
    public Transform SpawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 5f;
    private int WaveNumber = 500;

    void Start()
    {

    }
    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnArrow());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnArrow()
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
        Instantiate(ArrowPrefeb, SpawnPoint.position, Quaternion.Euler(90,0,0));
    }


}