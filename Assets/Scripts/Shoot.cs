using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletOrigin;
    [SerializeField] private float fireInterval;
    private ObjectPool objectPool;

    [Header("Sounds")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip ShotSound;

    void Start()
    {
        objectPool = ObjectPool.Instance;
        InvokeRepeating("SpawnBullet", 0.2f, fireInterval);
    }
    
    public void SpawnBullet()
    {
        audioSource.PlayOneShot(ShotSound);

          GameObject bullet = objectPool.GetPooledEnemyBullet(); 
          if (bullet != null) {
            bullet.transform.SetPositionAndRotation(bulletOrigin.transform.position, bulletPrefab.transform.rotation);
            bullet.SetActive(true);
          }
    }
}
