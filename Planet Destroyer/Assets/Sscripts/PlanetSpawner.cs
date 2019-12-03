using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public float timeToSpawnPlanet;
    private float currentTimeToSpawnPlanet;
    public int numberOfPlanetsToSpawn;
    public GameObject planet;
    public float distanceFromPlanets;

    public int numberOfEnnemiesToSpawn;
    public GameObject ennemy;

    private void Start()
    {
        currentTimeToSpawnPlanet = timeToSpawnPlanet;
    }

    private void Update()
    {
        CountDown();
    }

    private void CountDown()
    {
        currentTimeToSpawnPlanet -= Time.deltaTime;
        if (currentTimeToSpawnPlanet <= 0)
        {
            SpawnPlanets();
            SpawnEnnemies();
            currentTimeToSpawnPlanet = timeToSpawnPlanet;
        }
    }

    private void SpawnEnnemies()
    {
        for (int i = 0; i < numberOfEnnemiesToSpawn; i++)
        {
            Vector3 randomPos = UnityEngine.Random.insideUnitSphere * distanceFromPlanets + transform.position;
            Instantiate(ennemy, randomPos, Quaternion.identity);
        }
    }

    private void SpawnPlanets()
    {
        for (int i = 0; i < numberOfPlanetsToSpawn; i++)
        {
            Vector3 randomPos = UnityEngine.Random.insideUnitSphere * distanceFromPlanets + transform.position;
            Instantiate(planet, randomPos, Quaternion.identity);
        }
    }
}
