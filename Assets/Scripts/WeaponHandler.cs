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
    }
    /// <summary>
    /// Animator event
    /// </summary>
    private void DisableWeapon()
    {
        blade.SetActive(false);
    }
    
    /// <summary>
    /// Animator Event
    /// </summary>
    private void Hit()
    {
        
    }
}
