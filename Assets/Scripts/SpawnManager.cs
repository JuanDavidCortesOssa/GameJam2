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
    [SerializeField] private float objectsSpawnInterval;
    [SerializeField] private List<GameObject> objectsList;


    private void Start()
    {
        superiorPosition = superiorBoundTransform.position;
        inferiorPosition = inferiorBoundTransform.position;

        InvokeRepeating("SpawnGameEnemies", enemiesFirstSpawnTime, enemiesSpawnInterval);
        InvokeRepeating("SpawnGameObjects", objectsFirstSpawnTime, objectsSpawnInterval);
    }

    public void SpawnGameObjects()
    {
        int randomObjectNumber = Random.Range(0, objectsList.Count);

        Vector3 randomPosition = new(superiorPosition.x, 
            Random.Range(superiorPosition.y, inferiorPosition.y), superiorPosition.z);

        Instantiate(objectsList[randomObjectNumber], randomPosition, objectsList[randomObjectNumber].transform.rotation);
    }

    public void SpawnGameEnemies()
    {
        int randomObjectNumber = Random.Range(0, enemiesList.Count);

        Vector3 randomPosition = new(superiorPosition.x,
            Random.Range(superiorPosition.y, inferiorPosition.y), superiorPosition.z);

        Instantiate(enemiesList[randomObjectNumber], randomPosition, enemiesList[randomObjectNumber].transform.rotation);
    }

}
