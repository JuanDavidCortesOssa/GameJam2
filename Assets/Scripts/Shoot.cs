using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    void Start()
    {
        InvokeRepeating("SpawnBullet", 0.2f, 0.5f);
    }
    
    public void SpawnBullet()
    {
        Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
    }
}
