using System;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace Combat.Targeting
{
    public class Targeter : MonoBehaviour
    {
        [SerializeField] private CinemachineTargetGroup cinemachineTargetGroup;
        
        private List<Target> _targets = new List<Target>();
        
        public Target CurrentTarget { get; private set; }

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

        public bool SelectTarget()
        {
            if(_targets.Count == 0){return false;}

            CurrentTarget = _targets[0];
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
