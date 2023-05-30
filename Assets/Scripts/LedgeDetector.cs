using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeDetector : MonoBehaviour
{
    public event Action<Vector3, Vector3> OnLedgdeDetect; 

    private void OnTriggerEnter(Collider other)
    {
        OnLedgdeDetect?.Invoke(other.ClosestPoint(transform.position), other.transform.forward);
    }
}
