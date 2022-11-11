using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform superiorBoundTransform;
    private Vector3 superiorPosition;

    [SerializeField] private Transform inferiorBoundTransform;
    private Vector3 inferiorPosition;

    [SerializeField] private List<GameObject> spawnList;

    private void Start()
    {
        superiorPosition = superiorBoundTransform.position;
        inferiorPosition = inferiorBoundTransform.position;

        InvokeRepeating("SpawnGameObjects", 2f, 1f);
    }

    public void SpawnGameObjects()
    {
        int randomObjectNumber = Random.Range(0, spawnList.Count);

        Vector3 randomPosition = new(superiorPosition.x, 
            Random.Range(superiorPosition.y, inferiorPosition.y), superiorPosition.z);

        Instantiate(spawnList[randomObjectNumber], randomPosition, spawnList[randomObjectNumber].transform.rotation);
    }

}
