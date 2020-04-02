using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BTS.Manager.LevelManager;

using Entity.Actor.Character.Enemy;

namespace States.EnemyStates
{
    public class EnemyCheckingState : StateMachineBehaviour
    {
        private Enemy _script;

        Quaternion _targetRotation;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (_script == null)
                _script = animator.transform.GetComponent<Enemy>();

            _script.currentState = Enemy.States.Checking;

            Vector3 _target = CalculateTargetPosition();
            SetTarget(_target);
            RemoveTargetFromTheList(_target);

            _script.ChangeState(Enemy.States.Patrol.ToString());
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            /*if(_script.transform.rotation == _targetRotation)
                _script.ChangeState(Enemy.States.Patrol.ToString());*/
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _script.LookAtTarget();
        }

        #region Private Methods

        #region Target

        private Vector3 CalculateTargetPosition()
        {
            float _minDistanceToTarget = float.PositiveInfinity;
            Vector3 _currentTarget = Vector3.zero;

            float _distanceToTarget;

            foreach (Vector3 target in _script.GetTargets())
            {
                _distanceToTarget = Vector3.Distance(_script.transform.position, target);
                if (_minDistanceToTarget > _distanceToTarget)
                {
                    if(target != _currentTarget)
                    {
                        _currentTarget = target;
                        _minDistanceToTarget = _distanceToTarget;
                    }
                }
            }

            return _currentTarget;
        }

        #region SetTarget

        private void SetTarget(Vector3 currentTarget)
        {
            SetTargetPosition(currentTarget);
            SetTargetRotation(currentTarget);
        }

        private void SetTargetPosition(Vector3 target)
        {
            _script.SetTargetPosition(target);
        }

        private void SetTargetRotation(Vector3 target)
        {
            _targetRotation = Quaternion.LookRotation(target - _script.transform.position);
            _script.SetTargetRotation(_targetRotation);
        }

        #endregion

        private void RemoveTargetFromTheList(Vector3 target)
        {
            _script.RemoveTarget(target);
        }

        #endregion

        #endregion
    }
}
