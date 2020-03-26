using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Entity.Actor.Item.WaveSpawner;

using BTS.Manager.GameManager;

namespace States.GameManagerStates
{
    public class GMGameplayWaveState : StateMachineBehaviour
    {
        private WaveSpawner _waveSpawner;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            GameManager.Instance.currentState = GameManager.States.Wave;

            _waveSpawner = GameManager.Instance.waveSpawner;

            _waveSpawner.ChangeState(WaveSpawner.States.Cooldown.ToString());
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (Input.GetKeyDown(GameManager.Instance.die))
            {
                GameManager.Instance.ChangeState(GameManager.States.GameOver.ToString());
            }
            
            if(_waveSpawner.enemies.Count > 0)
            {
                if (Input.GetKeyDown(GameManager.Instance.destroyOneEnemy))
                {
                    Destroy(_waveSpawner.enemies[0]);
                    _waveSpawner.enemies.RemoveAt(0);
                }
            }
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }
    }
}
