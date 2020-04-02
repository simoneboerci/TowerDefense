using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Entity.Actor.Character.Enemy;

namespace States.EnemyStates
{
    public class EnemyPatrolState : StateMachineBehaviour
    {
        #region Private Variables

        private Enemy _script;

        private float _speed;

        #region Positions

        Vector3 _currentPosition;
        Vector3 _targetPosition;

        private float _maxPositionOffset = 0.15f;

        #endregion

        #endregion

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (_script == null)
                _script = animator.transform.GetComponent<Enemy>();

            _script.currentState = Enemy.States.Patrol;

            _targetPosition = _script.GetCurrentTarget();

            _speed = _script.GetData().movementSpeed;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            UpdatePosition();

            if (TargetReached())
            {
                _script.ChangeState(Enemy.States.Checking.ToString());
            }
            else
            {
                _script.transform.Translate(Vector3.forward * _speed * Time.deltaTime);
            }
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }

        #region Private Methods

        private void UpdatePosition()
        {
            _currentPosition = _script.transform.position;
        }

        private bool TargetReached()
        { 
            if (_currentPosition.x <= _targetPosition.x + _maxPositionOffset && _currentPosition.x > _targetPosition.x - _maxPositionOffset && _currentPosition.z <= _targetPosition.z + _maxPositionOffset && _currentPosition.z > _targetPosition.z - _maxPositionOffset)
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}
