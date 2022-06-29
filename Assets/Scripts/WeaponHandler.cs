using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private Collider bladeCollider;

    public void EnableWeapon()
    {
        bladeCollider.enabled = true;
    }
    public void DisableWeapon()
    {
        bladeCollider.enabled = false;
    }
}
