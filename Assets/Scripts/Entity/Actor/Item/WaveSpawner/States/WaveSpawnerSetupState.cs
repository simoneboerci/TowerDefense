using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawnerSetupState : StateMachineBehaviour
{
    private WaveSpawner _script;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(_script == null)
            _script = animator.transform.GetComponent<WaveSpawner>();

        _script.ChangeState(WaveSpawner.States.Cooldown);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
