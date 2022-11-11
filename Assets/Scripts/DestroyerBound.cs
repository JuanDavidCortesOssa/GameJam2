using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerBound : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.transform.root.gameObject);
    }
}
