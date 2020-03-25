using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Entity.Actor.Item.WaveSpawner;

using BTS.Manager.LevelManager;

using Data.Wave;

namespace Entity.Actor.Item.WaveSpawner
{
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

        //Enemy parent
        public Transform enemyPool;
        
        [HideInInspector]
        public List<GameObject> enemies = new List<GameObject>();

        #endregion

        #region Private Variables

        private Animator _animator;

        //The points from which the enemies will come
        private List<Vector3> _start;

        #endregion

        #region Init

        private void Awake()
        {
            _animator = GetComponent<Animator>();

            _start = LevelManager.Instance.GetStart();
        }

        #endregion

        #region Public Methods

        //Change the state of the State Machine
        public void ChangeState(States state)
        {
            _animator.SetTrigger(state.ToString());
        }

        #region Wave Spawning

        public void StartWave()
        {
            StartCoroutine(SpawnHorde(LevelManager.Instance.GetCurrentWave()));
        }

        #region Spawn

        private IEnumerator SpawnHorde(Wave wave)
        {
            //Spawn the enemies of every horde
            for (int i = 0; i < wave.hordes.Count; i++)
            {
                yield return StartCoroutine(SpawnEnemies(wave.hordes[i]));

                yield return new WaitForSeconds(wave.hordes[i].cooldown);
            }

            //Wait when you're done spawning
            ChangeState(States.Wait);
        }

        private IEnumerator SpawnEnemies(Horde horde)
        {
            //For each enemies
            for (int i = 0; i < horde.enemyCount; i++)
            {
                //Get a random spawn point from the possible ones
                Vector3 _randomPosition = _start[Random.Range(0, _start.Count)];

                //Instantiate the enemy
                GameObject _enemy = Instantiate(horde.enemy, _randomPosition, Quaternion.identity, enemyPool);

                //Store the enemy
                enemies.Add(_enemy);

                //Wait to respect the spawn rate
                yield return new WaitForSeconds(1f / horde.spawnRate);
            }
        }

        #endregion

        #endregion

        #endregion
    }
}
