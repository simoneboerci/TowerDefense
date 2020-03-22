using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Data.Wave;

[RequireComponent(typeof(Animator))]
public class WaveSpawner : MonoBehaviour
{
    #region Public Variables

    public enum States
    {
        Cooldown,
        Spawn,
        Wait,
    }

    public List<Wave> waves;

    #endregion

    #region Private Variables

    private Animator _animator;

    #endregion

    #region Init

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    #endregion

    #region Public Methods

    public void ChangeState(States state)
    {
        _animator.SetTrigger(state.ToString());
    }

    #endregion
}
