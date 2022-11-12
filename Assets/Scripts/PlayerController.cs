using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private bool hasPowerUp = false;
    private float verticalBoundary;
    private float horizontalBoundary;
    public float currentOxygen { get; private set; }

    [Header("Ship Setup")]
    [SerializeField] private float speed;
    [SerializeField] float powerUpDuration;
    [SerializeField] float maxOxygen;

    [Space()]
    [Header("Ship's armament")]
    [SerializeField] private List<BulletManager> guns;
    [SerializeField] private GameObject shield;

    [Space()]
    [Header("Map reference")]
    [SerializeField] GameObject background;

    // Start is called before the first frame update
    void Start()
    {
        currentOxygen = maxOxygen;

        verticalBoundary = background.GetComponent<MeshRenderer>().bounds.max.y;
        horizontalBoundary = background.GetComponent<MeshRenderer>().bounds.max.x;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        ReduceOxygen();
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

        if (transform.position.y >= verticalBoundary)
        {
            transform.position = new Vector3(transform.position.x, verticalBoundary, transform.position.z);
        }
        else if (transform.position.y <= -verticalBoundary)
        {
            transform.position = new Vector3(transform.position.x, -verticalBoundary, transform.position.z);
        }
        else if (transform.position.x >= horizontalBoundary)
        {
            transform.position = new Vector3(horizontalBoundary, transform.position.y, transform.position.z);
        }
        else if (transform.position.x <= -horizontalBoundary)
        {
            transform.position = new Vector3(-horizontalBoundary, transform.position.y, transform.position.z);
        }
    }

    private void Shoot()
    {
        foreach (BulletManager gun in guns)
        {
            if (gun.isActiveAndEnabled == true) gun.CreateBullet();
        }
    }

    private void ReduceOxygen()
    {
        if (currentOxygen > 0)
        {
            currentOxygen -= Time.deltaTime;
        }
        else if (currentOxygen <= 0)
        {
            currentOxygen = 0;
            Debug.Log("Game Over");
        }
    }

    public void AddOxygen(float value)
    {
        if(currentOxygen + value < maxOxygen)
            currentOxygen += value;
        else
            currentOxygen = maxOxygen;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp")) StartCoroutine(SetPowerUp());
        else if (other.CompareTag("Enemy") && !hasPowerUp) Destroy(gameObject);

        if (!other.CompareTag("PlayerBullet")) Destroy(other.gameObject);
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
        for (int i = 1; i < guns.Count; i++)
        {
            if (activate) guns[i].gameObject.SetActive(true);
            else guns[i].gameObject.SetActive(false);
        }
    }
}
