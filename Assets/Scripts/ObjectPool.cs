using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool>
{
    [Header("EnemyBullets")]
    [SerializeField] private Transform enemyBulletsParent;
    [SerializeField] private GameObject enemyBulletGO;
    [SerializeField] private int bulletsAmount;
    private List<GameObject> pooledEnemyBullets;

    [Header("Astheroids")]
    [SerializeField] private Transform astheroidsParent;
    [SerializeField] private GameObject asteroidGO;
    [SerializeField] private int asteroidsAmount;
    private List<GameObject> pooledAsteroids;

    [Header("ALienShip")]
    [SerializeField] private Transform alienShipParent;
    [SerializeField] private GameObject alienShipGO;
    [SerializeField] private int shipsAmount;
    private List<GameObject> pooledShips;

    void Start()
    {
        pooledEnemyBullets = new List<GameObject>();
        GameObject tmpBullet;
        for (int i = 0; i < bulletsAmount; i++)
        {
            tmpBullet = Instantiate(enemyBulletGO,enemyBulletsParent);
            tmpBullet.SetActive(false);
            pooledEnemyBullets.Add(tmpBullet);
        }

        pooledAsteroids = new List<GameObject>();
        GameObject tmpAstheroid;
        for (int i = 0; i < asteroidsAmount; i++)
        {
            tmpAstheroid = Instantiate(asteroidGO,astheroidsParent);
            tmpAstheroid.SetActive(false);
            pooledAsteroids.Add(tmpAstheroid);
        }

        pooledShips = new List<GameObject>();
        GameObject tmpShip;
        for (int i = 0; i < shipsAmount; i++)
        {
            tmpShip = Instantiate(alienShipGO,alienShipParent);
            tmpShip.SetActive(false);
            pooledShips.Add(tmpShip);
        }
    }

    public GameObject GetPooledEnemyBullet()
    {
        for(int i = 0; i < bulletsAmount; i++)
        {
            if(!pooledEnemyBullets[i].activeInHierarchy)
            {
                return pooledEnemyBullets[i];
            }
        }
        return null;
    }

    public GameObject GetPooledAsteroid()
    {
        for (int i = 0; i < asteroidsAmount; i++)
        {
            if (!pooledAsteroids[i].activeInHierarchy)
            {
                return pooledAsteroids[i];
            }
        }
        return null;
    }

    public GameObject GetPooledShip()
    {
        for (int i = 0; i < shipsAmount; i++)
        {
            if (!pooledShips[i].activeInHierarchy)
            {
                return pooledShips[i];
            }
        }
        return null;
    }

}
