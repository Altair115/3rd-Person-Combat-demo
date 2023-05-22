using UnityEngine;

namespace Combat
{
    public class Ragdoll : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private CharacterController _controller;

        private Collider[] _allColliders;
        private Rigidbody[] _allRigidbodies;
    
        private void Start()
        {
            _allColliders = GetComponentsInChildren<Collider>(true);
            _allRigidbodies = GetComponentsInChildren<Rigidbody>(true);
            ToggleRagdoll(false);
        }

        /// <summary>
        /// Turns on the ragdoll for the object
        /// </summary>
        /// <param name="isRagdoll"></param>
        public void ToggleRagdoll(bool isRagdoll)
        {
            foreach (Collider collider in _allColliders)
            {
                if (collider.gameObject.CompareTag("Ragdoll"))
                {
                    collider.enabled = isRagdoll;
                }
            }

            foreach (Rigidbody rigidbody in _allRigidbodies)
            {
                if (rigidbody.gameObject.CompareTag("Ragdoll"))
                {
                    rigidbody.isKinematic = !isRagdoll;
                    rigidbody.useGravity = isRagdoll;
                }
            }

            _controller.enabled = !isRagdoll;
            _animator.enabled = !isRagdoll;
        }
    }
}
