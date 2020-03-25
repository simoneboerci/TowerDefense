using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Entity.Actor.Item.WaveSpawner;

using BTS.Manager.LevelManager;

namespace States.WaveSpawnerStates
{
    public class WaveSpawnerWaitState : StateMachineBehaviour
    {
        private WaveSpawner _script;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (_script == null)
                _script = animator.transform.GetComponent<WaveSpawner>();
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            #region TEST

            if (_script.enemies.Count > 0)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    Destroy(_script.enemies[0]);
                    _script.enemies.RemoveAt(0);
                }
            }

            #endregion

            if (_script.enemies.Count <= 0)
            {
                if (LevelManager.Instance.NextWave())
                {
                    _script.ChangeState(WaveSpawner.States.Cooldown);
                }
            }
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }
    }
}