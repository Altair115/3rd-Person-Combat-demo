using System;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace Combat.Targeting
{
    public class Targeter : MonoBehaviour
    {
        [SerializeField] private CinemachineTargetGroup cinemachineTargetGroup;

        private Camera _mainCamera;
        private List<Target> _targets = new List<Target>();
        
        public Target CurrentTarget { get; private set; }

        private void Start()
        {
            _mainCamera = Camera.main;
        }
        
        public void OnTriggerEnter(Collider other)
        {
            if(!other.TryGetComponent<Target>(out Target target)) {return;}
            
            _targets.Add(target);
            target.OnDestroyed += RemoveTarget;
        }

        private void OnTriggerExit(Collider other)
        {
           if(!other.TryGetComponent<Target>(out Target target)) {return;}
           
           RemoveTarget(target);
        }

        private void RemoveTarget(Target target)
        {
            if (CurrentTarget == target)
            {
                cinemachineTargetGroup.RemoveMember(CurrentTarget.transform);
                CurrentTarget = null;
            }
            
            target.OnDestroyed -= RemoveTarget;
            _targets.Remove(target);
        }

        /// <summary>
        /// looks for the closed target-able thing to the center of the screen(viewport)
        /// </summary>
        /// <returns>the closest to the center target</returns>
        public bool SelectTarget()
        {
            if(_targets.Count == 0){return false;}

            Target closestTarget = null;
            float closestTargetDistance = Mathf.Infinity;

            foreach (Target target in _targets)
            {
                Vector2 viewPosition = _mainCamera.WorldToViewportPoint(target.transform.position);

                if (!target.GetComponentInChildren<Renderer>().isVisible)
                {
                    continue;
                }

                Vector2 toCenter = viewPosition - new Vector2(0.5f, 0.5f);
                if (toCenter.sqrMagnitude < closestTargetDistance)
                {
                    closestTarget = target;
                    closestTargetDistance = toCenter.sqrMagnitude;
                }
            }

            if (closestTarget == null) { return false;}

            CurrentTarget = closestTarget;
            cinemachineTargetGroup.AddMember(CurrentTarget.transform, 1f, 2f);

            return true;
        }

        public void Cancel()
        {
            if(CurrentTarget == null) return;
            
            cinemachineTargetGroup.RemoveMember(CurrentTarget.transform);
            
            CurrentTarget = null;
        }
    }
}
