using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BTS.Manager.GameManager;

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

            _script.currentState = WaveSpawner.States.Wait;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (GameManager.Instance.currentState == GameManager.States.Wave && _script.enemies.Count <= 0)
            {
                GameManager.Instance.ChangeState(GameManager.States.Victory.ToString());
            }
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }
    }
}