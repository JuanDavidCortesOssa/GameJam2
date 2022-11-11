using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EnemyLifeManager : MonoBehaviour
{
    [SerializeField] private Image lifeBarImage;

    [Tooltip("Number of shots that the object resist")]
    [SerializeField] private int resistance;
    private float damagePerShot = 1;

    void Start()
    {
        damagePerShot = (float)1 / resistance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            GetDamaged();
        }
    }

    private void GetDamaged()
    {
        float currentLife = lifeBarImage.fillAmount;
        float updatedLife = currentLife - damagePerShot;

        if (updatedLife >= 0.1)
        {
            lifeBarImage.DOFillAmount(lifeBarImage.fillAmount - damagePerShot, 0.2f);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
