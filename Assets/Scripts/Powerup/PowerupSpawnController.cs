using System;
using UnityEngine;

public class PowerupSpawnController : MonoBehaviour
{
    [SerializeReference]
    private int spawnDelay = 10;

    [SerializeReference]
    private int variance = 3;

    [SerializeReference]
    private bool spawnOnStart = false;

    [SerializeReference]
    private GameObject[] powerups;

    private DateTime nextSpawnTime;

    void Start()
    {
        if (spawnOnStart) SpawnPowerup();
        else SetNextPowerupTime();
    }

    void Update()
    {
        if (!HasPowerup() && DateTime.Now >= nextSpawnTime) SpawnPowerup();
    }

    void SetNextPowerupTime()
    {
        nextSpawnTime = DateTime.Now.AddSeconds(spawnDelay + Offset);
    }

    void SpawnPowerup()
    {
        GameObject powerup = Instantiate(powerups[0], transform);
        powerup.GetComponent<Powerup>().OnDestroyed += SetNextPowerupTime;
    }

    void OnPowerupDestroyed() {
        SetNextPowerupTime();
    }

    bool HasPowerup() {
        return GetComponentInChildren<Powerup>() != null;
    }

    int Offset
    {
         get
         {
             return new System.Random(DateTime.Now.Millisecond).Next(variance * 2) - variance;
         }
    }
}
