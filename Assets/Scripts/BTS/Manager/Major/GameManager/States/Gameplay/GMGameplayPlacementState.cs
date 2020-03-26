using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BTS.Manager.GameManager;

namespace States.GameManagerStates
{
    public class GMGameplayPlacementState : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            GameManager.Instance.currentState = GameManager.States.Placement;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (Input.GetKeyDown(GameManager.Instance.nextWave))
            {
                GameManager.Instance.ChangeState(GameManager.States.Wave.ToString());
            }
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            
        }
    }
}
