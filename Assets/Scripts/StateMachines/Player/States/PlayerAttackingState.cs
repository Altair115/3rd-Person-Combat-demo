using UnityEngine;

namespace StateMachines.Player.States
{
    public class PlayerAttackingState : PlayerBaseState
    {
        private float _previousFrameTime;
        private bool _alreadyAppliedForce;
        private Attack _attack;
    
        public PlayerAttackingState(PlayerStateMachine stateMachine, int attackIndex) : base(stateMachine)
        {
            _attack = stateMachine.Attacks[attackIndex];
        }

        public override void Enter()
        {
            _stateMachine.Weapon.SetAttack(_attack.DamageAmount);
            _stateMachine.Animator.CrossFadeInFixedTime(_attack.AnimationName, _attack.TransitionDuration);
        }

        public override void Tick(float deltaTime)
        {
            Move(deltaTime);
            FaceTarget();
            
            float normalizedTime = GetNormalizedTime();

            if (normalizedTime >= _previousFrameTime && normalizedTime < 1f)
            {
                if (normalizedTime >= _attack.ForceTime)
                {
                    TryApplyForce();
                }
                
                if (_stateMachine.InputReader.IsAttacking)
                {
                    TryComboAttack(normalizedTime);
                }
            }
            else
            {
                if (_stateMachine.Targeter.CurrentTarget != null)
                {
                    _stateMachine.SwitchState(new PlayerTargetingState(_stateMachine));
                }
                else
                {
                    _stateMachine.SwitchState(new PlayerFreeLookState(_stateMachine));
                }
            }
            _previousFrameTime = normalizedTime;
        }
        
        public override void Exit()
        {
            
        }
        
        private void TryComboAttack(float normalizedTime)
        {
            if(_attack.ComboStateIndex == -1){return;}
            if(normalizedTime < _attack.ComboAttackTime){return;}
            _stateMachine.SwitchState(new PlayerAttackingState(_stateMachine, _attack.ComboStateIndex));
        }

        private void TryApplyForce()
        {
            if(_alreadyAppliedForce){return;}
            _stateMachine.ForceReciever.AddForce(_stateMachine.transform.forward * _attack.Force);
            _alreadyAppliedForce = true;
        }

        private float GetNormalizedTime()
        {
            AnimatorStateInfo currentInfo = _stateMachine.Animator.GetCurrentAnimatorStateInfo(0);
            AnimatorStateInfo nextInfo = _stateMachine.Animator.GetNextAnimatorStateInfo(0);

            if (_stateMachine.Animator.IsInTransition(0) && nextInfo.IsTag("Attack"))
            {
                return nextInfo.normalizedTime;
            }
            else if(!_stateMachine.Animator.IsInTransition(0) && currentInfo.IsTag("Attack"))
            {
                return currentInfo.normalizedTime;
            }
            else
            {
                return 0;
            }
        }
    }
}
