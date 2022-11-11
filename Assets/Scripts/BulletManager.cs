using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    // Start is called before the first frame update
    Vector3 direction;
    void Start()
    {
        direction = (transform.localRotation * Vector3.right).normalized;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateBullet()
    {
        //if(gameObject.activeInHierarchy == true) Debug.Log("active");
        bullet.direction = direction;
        Instantiate(bullet, transform.position + Vector3.forward, Quaternion.identity);
       
    }

}
