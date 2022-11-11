using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private float horizontalInput;
    private float verticalInput;
    private BulletManager bulletManager;
    [SerializeField] private bool hasPowerUp = false;

    // Start is called before the first frame update
    void Start()
    {
        bulletManager = GetComponentInChildren<BulletManager>();
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
        bulletManager.CreateBullet();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
           
           StartCoroutine(ReestorePowerUp(other.gameObject));
        }
    }

    private IEnumerator ReestorePowerUp(GameObject powerUpObject)
    {
        Destroy(powerUpObject);
        hasPowerUp = true;

        yield return new WaitForSeconds(3);
        hasPowerUp = false;
    }
}
