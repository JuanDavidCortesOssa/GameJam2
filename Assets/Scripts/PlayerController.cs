using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private bool hasPowerUp = false;
    
    [Header("Ship Setup")]
    [SerializeField] private float speed;
    [SerializeField] float powerUpDuration;
   

    [Space()]
    [Header("Ship's armament")]
    [SerializeField] private List<BulletManager> guns;
    [SerializeField] private GameObject shield;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        if (Input.GetKeyDown(KeyCode.F))
        {
            Shoot();
        }
    }

    private void PlayerMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        transform.Translate(Vector3.up * verticalInput * speed * Time.deltaTime);
    }

    private void Shoot()
    {
        foreach(BulletManager gun in guns)
        {
            if(gun.isActiveAndEnabled == true) gun.CreateBullet();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp")) StartCoroutine(SetPowerUp());
        else if (other.CompareTag("Enemy") && !hasPowerUp) Destroy(gameObject);

        Destroy(other.gameObject);

    }

    private IEnumerator SetPowerUp()
    {
        hasPowerUp = true;
        SetPowerUpGuns(true);
        shield.SetActive(true);

        yield return new WaitForSeconds(powerUpDuration);

        hasPowerUp = false;
        SetPowerUpGuns(false);
        shield.SetActive(false);
      
    }

    private void SetPowerUpGuns(bool activate)
    {
        for(int i = 1; i < guns.Count; i++)
        {
            if(activate) guns[i].gameObject.SetActive(true);
            else guns[i].gameObject.SetActive(false);
        }
    }
}
