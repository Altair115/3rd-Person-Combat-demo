using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private GameObject blade;
    
    /// <summary>
    /// Animator event
    /// </summary>
    private void EnableWeapon()
    {
        blade.SetActive(true);
        Debug.Log("ON");
    }
    /// <summary>
    /// Animator event
    /// </summary>
    private void DisableWeapon()
    {
        blade.SetActive(false);
        Debug.Log("OFF");
    }
    
    /// <summary>
    /// Animator Event
    /// </summary>
    private void Hit()
    {
        
    }
}
