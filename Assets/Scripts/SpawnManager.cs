using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Boundaries")]
    [SerializeField] private Transform superiorBoundTransform;
    private Vector3 superiorPosition;

    [SerializeField] private Transform inferiorBoundTransform;
    private Vector3 inferiorPosition;

    [Header("Enemies")]
    [SerializeField] private float enemiesFirstSpawnTime;
    [SerializeField] private float enemiesSpawnInterval;
    [SerializeField] private List<GameObject> enemiesList;

    [Header("Objects")]
    [SerializeField] private float objectsFirstSpawnTime;
    [SerializeField] private float powerUpSpawnInterval;
    [SerializeField] private float oxygenSpawnInterval;
    [SerializeField] private GameObject oxygen;
    [SerializeField] private GameObject powerUp;


    private void Start()
    {
        superiorPosition = superiorBoundTransform.position;
        inferiorPosition = inferiorBoundTransform.position;

        InvokeRepeating("SpawnGameEnemies", enemiesFirstSpawnTime, enemiesSpawnInterval);
        InvokeRepeating("SpawnPowerUp", Random.Range(5, 10), powerUpSpawnInterval);
        InvokeRepeating("SpawnOxygen", Random.Range(4, 8), oxygenSpawnInterval);
    }

    public void SpawnPowerUp()
    {
        Vector3 randomPosition = new(superiorPosition.x, 
            Random.Range(superiorPosition.y, inferiorPosition.y), superiorPosition.z);

        Instantiate(powerUp, randomPosition, powerUp.transform.rotation);
    }

    public void SpawnOxygen()
    {
        Vector3 randomPosition = new(superiorPosition.x, 
            Random.Range(superiorPosition.y, inferiorPosition.y), superiorPosition.z);

        Instantiate(oxygen, randomPosition, oxygen.transform.rotation);
    }

    public void SpawnGameEnemies()
    {
        int randomObjectNumber = Random.Range(0, enemiesList.Count);

        Vector3 randomPosition = new(superiorPosition.x,
            Random.Range(superiorPosition.y, inferiorPosition.y), superiorPosition.z);

        Instantiate(enemiesList[randomObjectNumber], randomPosition, enemiesList[randomObjectNumber].transform.rotation);
    }

}
