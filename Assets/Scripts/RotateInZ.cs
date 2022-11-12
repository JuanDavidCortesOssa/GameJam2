using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateInZ : MonoBehaviour
{
    public float rotationSpeed;

    private void Update()
    {
        transform.Rotate(0,0, rotationSpeed * Time.deltaTime);
    }
}
