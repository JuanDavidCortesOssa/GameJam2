using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletOrigin;
    [SerializeField] private float fireInterval;

    void Start()
    {
        InvokeRepeating("SpawnBullet", 0.2f, fireInterval);
    }
    
    public void SpawnBullet()
    {
        Instantiate(bulletPrefab, bulletOrigin.position, bulletPrefab.transform.rotation);
    }
}
