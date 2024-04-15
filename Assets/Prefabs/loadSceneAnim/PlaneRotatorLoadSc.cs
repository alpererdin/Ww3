using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneRotatorLoadSc : MonoBehaviour
{
    public float t = 100f;
    private void FixedUpdate()
    {
        Quaternion currentRotation = transform.rotation;
        Quaternion rotationDelta = Quaternion.Euler(0, 0, t * Time.deltaTime);
        transform.rotation = currentRotation * rotationDelta;
    }
}
