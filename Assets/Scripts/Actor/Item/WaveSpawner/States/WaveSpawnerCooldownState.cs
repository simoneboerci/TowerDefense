using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Entity.Actor.Item.WaveSpawner;

using BTS.Manager.LevelManager;

namespace States.WaveSpawnerStates
{
    public class WaveSpawnerCooldownState : StateMachineBehaviour
    {
        private WaveSpawner _script;

        private float _timer;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (_script == null)
                _script = animator.transform.GetComponent<WaveSpawner>();

            _script.currentState = WaveSpawner.States.Cooldown; 

            _timer = LevelManager.Instance.GetCurrentWave().delay;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (_timer > 0f)
            {
                _timer -= Time.deltaTime;
            }
            else
            {
                _script.ChangeState(WaveSpawner.States.Spawn.ToString());
            }
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }
    }
}
