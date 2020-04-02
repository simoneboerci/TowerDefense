using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BTS.Manager.LevelManager;

using Entity.Actor.Character.Enemy;

using Data.Characters.Enemy;

namespace States.EnemyStates
{
    public class EnemySetupState : StateMachineBehaviour
    {
        private Enemy _script;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if(_script == null)
                _script = animator.transform.GetComponent<Enemy>();

            SetupEnemy();
            SetupEnemyTargets();

            _script.ChangeState(Enemy.States.Checking.ToString());
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }

        #region Private Methods

        #region SetupEnemy

        private void SetupEnemy()
        {
            EnemyData _data = _script.GetData();

            SetEnemySize(_data);
            _script.SetLife();
            _script.SetDefaultColor();
        }

        private void SetEnemySize(EnemyData data)
        {
            float _size = data.size;
            _script.transform.localScale = new Vector3(_size, _size, _size);
        }

        #endregion

        private void SetupEnemyTargets()
        {
            //Store the position of every terrain tile
            foreach (Vector3 target in LevelManager.Instance.path)
            {
                _script.AddTarget(target);
            }

            //Store the position of every possible end
            foreach (Vector3 t in LevelManager.Instance.GetEnd())
            {
                _script.AddTarget(t);
            }
        }

        #endregion
    }
}
