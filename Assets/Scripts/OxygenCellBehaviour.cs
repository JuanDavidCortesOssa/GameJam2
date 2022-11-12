using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenCellBehaviour : MonoBehaviour
{
    private PlayerController player;
    [SerializeField] private float oxygenCellValue;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            player = other.GetComponent<PlayerController>();
            player.AddOxygen(oxygenCellValue);
        }
    }
}
