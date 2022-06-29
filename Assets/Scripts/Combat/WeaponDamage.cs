using System;
using System.Collections.Generic;
using UnityEngine;

namespace Combat
{
    public class WeaponDamage : MonoBehaviour
    {
        [SerializeField] private Collider myCollider;

        private int _damage;
        private List<Collider> alreadyCollidedWith = new List<Collider>();

        private void OnEnable()
        {
            alreadyCollidedWith.Clear();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other == myCollider){return;}
            if(alreadyCollidedWith.Contains(other)){return;}
            alreadyCollidedWith.Add(other);

            if (other.TryGetComponent<Health>(out Health health))
            {
                health.DealDamage(_damage);
            }
        }

        public void SetAttack(int damage)
        {
            _damage = damage;
        }
    }
}
