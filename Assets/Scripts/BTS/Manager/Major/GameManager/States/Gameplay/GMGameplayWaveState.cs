using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Entity.Actor.Item.WaveSpawner;
using Entity.Actor.Character.Enemy;

using BTS.Manager.GameManager;

namespace States.GameManagerStates
{
    public class GMGameplayWaveState : StateMachineBehaviour
    {
        private WaveSpawner _waveSpawner;

        private float _timer = 0f;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _waveSpawner = GameManager.Instance.waveSpawner;

            _waveSpawner.ChangeState(WaveSpawner.States.Cooldown.ToString());

            _timer = 1f / GameManager.Instance.fireRate;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if(GameManager.Instance.currentState != GameManager.States.Wave)
                GameManager.Instance.currentState = GameManager.States.Wave;

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

                if (GameManager.Instance.autoFire)
                {
                    if(_timer > 0)
                    {
                        _timer -= Time.deltaTime;
                    }
                    else
                    {
                        _waveSpawner.enemies[0].GetComponent<Enemy>().GetDamage(GameManager.Instance.damage);
                        _timer = 1f / GameManager.Instance.fireRate;
                    }
                }
                else
                {
                    if (Input.GetKeyDown(GameManager.Instance.damageOneEnemy))
                    {
                        _waveSpawner.enemies[0].GetComponent<Enemy>().GetDamage(GameManager.Instance.damage);
                    }
                }     
            }
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }
    }
}
