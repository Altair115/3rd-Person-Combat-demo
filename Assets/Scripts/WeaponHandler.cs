using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private GameObject blade;

    /// <summary>
    /// Animator event
    /// </summary>
    public void EnableWeapon()
    {
        blade.SetActive(true);
    }
    /// <summary>
    /// Animator event
    /// </summary>
    public void DisableWeapon()
    {
        blade.SetActive(false);
    }
}
