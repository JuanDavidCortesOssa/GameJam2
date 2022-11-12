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

    [Header("Particles")]
    [SerializeField] private ParticleSystem hitParticle;
    [SerializeField] private ParticleSystem destroyedParticle;

    [Header("Sounds")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip destroyedSound;

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
            hitParticle.Play();
        }
        else
        {
            destroyedParticle.transform.parent = null;
            destroyedParticle.Play();

            audioSource.transform.parent = null;
            audioSource.PlayOneShot(destroyedSound);

            Destroy(destroyedParticle.gameObject, 2f);
            Destroy(audioSource.gameObject, 2f);
            Destroy(gameObject);
        }
    }
}
