using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BTS.Manager.LevelManager;
using BTS.Manager.GameManager;

namespace States.GameManagerStates
{
    public class GMGameplayVictoryState : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            GameManager.Instance.currentState = GameManager.States.Victory;

            if (LevelManager.Instance.NextWave())
            {
                GameManager.Instance.ChangeState(GameManager.States.Placement.ToString());
            }
            else
            {
                GameManager.Instance.ChangeState(GameManager.States.EndGame.ToString());
            }
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }
    }
}
