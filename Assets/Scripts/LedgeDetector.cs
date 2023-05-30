using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeDetector : MonoBehaviour
{
    public event Action<Vector3, Vector3> OnLedgdeDetect; 

    private void OnTriggerEnter(Collider other)
    {
        OnLedgdeDetect?.Invoke(other.transform.forward, other.ClosestPointOnBounds(transform.position));
    }
}
