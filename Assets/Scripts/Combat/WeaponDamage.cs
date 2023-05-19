using System.Collections.Generic;
using UnityEngine;

namespace Combat
{
    public class WeaponDamage : MonoBehaviour
    {
        [SerializeField] private Collider myCollider;

        private int _damage;
        private float _knockback;
        private List<Collider> _alreadyCollidedWith = new List<Collider>();

        private void OnEnable()
        {
            _alreadyCollidedWith.Clear();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other == myCollider){return;}
            if(_alreadyCollidedWith.Contains(other)){return;}
            _alreadyCollidedWith.Add(other);

            if (other.TryGetComponent<Health>(out Health health))
            {
                health.DealDamage(_damage);
            }

            if (other.TryGetComponent<ForceReciever>(out ForceReciever forceReciever))
            {
                Vector3 direction = (other.transform.position - myCollider.transform.position).normalized;
                forceReciever.AddForce(direction * _knockback);
            }
        }

        public void SetAttack(int damage, float knockback)
        {
            _damage = damage;
            _knockback = knockback;
        }
    }
}
