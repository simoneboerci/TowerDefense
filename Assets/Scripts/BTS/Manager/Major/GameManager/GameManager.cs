using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Entity.Actor.Item.WaveSpawner;

using Interfaces.IStateMachine;

namespace BTS.Manager.GameManager
{
    [RequireComponent(typeof(Animator))]
    public class GameManager : Manager<GameManager>, IStateMachine
    {
        #region Private Variables

        private Animator _animator;

        #endregion

        #region Public Methods

        public enum States
        {
            Gameplay,
            Placement,
            Wave,
            GameOver,
            Victory,
            EndGame,
        }

        public States currentState;

        public WaveSpawner waveSpawner;

        [Header("DEBUG")]
        public KeyCode nextWave;
        public KeyCode destroyOneEnemy;
        public KeyCode die;

        #endregion

        #region Init

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        #endregion

        #region Public Methods

        public void ChangeState(string state)
        {
            _animator.SetTrigger(state);
        }

        #endregion
    }
}
