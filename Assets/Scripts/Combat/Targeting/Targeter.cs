using System;
using System.Collections.Generic;
using UnityEngine;

namespace Combat.Targeting
{
    public class Targeter : MonoBehaviour
    {
        public List<Target> Targets = new List<Target>();

        public void OnTriggerEnter(Collider other)
        {
            if(!other.TryGetComponent<Target>(out Target target)) {return;}
            
            Targets.Add(target);
        }

        private void OnTriggerExit(Collider other)
        {
           if(!other.TryGetComponent<Target>(out Target target)) {return;}
           
           Targets.Remove(target);
        }
    }
}
