using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    [SerializeField] public string waveName;
    [SerializeField] public int limitMonster;
    [SerializeField] public GameObject[] typeMonster;
    [SerializeField] public float spawnfrequency;
}

public class WaveSpawnner : MonoBehaviour
{
    [SerializeField] public Wave[] waves;
    [SerializeField] public Transform[] spawnPoint;

    private Wave currentWave;
    private int currentWaveNumber;
    private float nextSpawnTime;

    [SerializeField] private bool canSpawn;

    [SerializeField] private float maxDelayWave;
    [SerializeField] private float delayWave;

    [SerializeField] float delayStartSpawn;
    [SerializeField] bool firstStart;

    private void Start()
    {
        delayWave = maxDelayWave;
        firstStart = true;
    }
    private void Update()
    {
        currentWave = waves[currentWaveNumber];

        if (delayStartSpawn > 0 && firstStart)
        {
            delayStartSpawn -= Time.deltaTime;
        }
        else if (delayStartSpawn <= 0)
        {
            SpawnWave();
            firstStart = false;
        }
        //// คำสั่งตรวจเช็คว่า Monster หายไปหมดแล้วหรือยัง ถ้าหายไปหมดแล้วจึงไปยัง Wave ต่อไป
        ///GameObject[] monsterInArea = GameObject.FindGameObjectsWithTag("Enemy");
        //if (monsterInArea.Length == 0 && !canSpawn && currentWaveNumber + 1 != waves.Length)
        //{
        //    SpawnNextWave();
        //}

        // ไป Wave ต่อไปหลังหมด Delay
        if (delayWave > 0 && !canSpawn && currentWaveNumber + 1 != waves.Length && Time.timeScale == 1)
        {
            delayWave -= Time.deltaTime;
        }
        else if (delayWave <= 0 && !canSpawn && currentWaveNumber + 1 != waves.Length)
        {
            SpawnNextWave();
            delayWave = maxDelayWave;
        }
    }

    void SpawnNextWave()
    {
        currentWaveNumber++;
        canSpawn = true;
    }

    void SpawnWave()
    {
        if (canSpawn && nextSpawnTime < Time.time)
        {
            GameObject randomEnemy = currentWave.typeMonster[Random.Range(0, currentWave.typeMonster.Length)];
            Transform randomPoint = spawnPoint[Random.Range(0, spawnPoint.Length)];
            Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
            currentWave.limitMonster--;
            nextSpawnTime = Time.time + currentWave.spawnfrequency;
            if (currentWave.limitMonster == 0)
            {
                canSpawn = false;
            }
        }

    }
}

