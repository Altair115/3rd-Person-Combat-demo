using System;
using System.Collections.Generic;
using UnityEngine;

namespace Combat.Targeting
{
    public class Targeter : MonoBehaviour
    {
        private List<Target> _targets = new List<Target>();
        
        public Target CurrentTarget { get; private set; }

        public void OnTriggerEnter(Collider other)
        {
            if(!other.TryGetComponent<Target>(out Target target)) {return;}
            
            _targets.Add(target);
        }

        private void OnTriggerExit(Collider other)
        {
           if(!other.TryGetComponent<Target>(out Target target)) {return;}
           
           _targets.Remove(target);
        }

        public bool SelectTarget()
        {
            if(_targets.Count == 0){return false;}

            CurrentTarget = _targets[0];

            return true;
        }

        public void Cancel()
        {
            CurrentTarget = null;
        }
    }
}
