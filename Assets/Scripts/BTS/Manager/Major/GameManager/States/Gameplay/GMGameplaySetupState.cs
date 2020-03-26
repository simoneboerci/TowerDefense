using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BTS.Manager.GameManager;

namespace States.GameManagerStates
{
    public class GMGameplaySetupState : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            GameManager.Instance.ChangeState(GameManager.States.Placement.ToString());
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }
    }
}
