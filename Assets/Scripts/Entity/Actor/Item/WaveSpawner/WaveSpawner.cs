using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BTS.Manager.LevelManager;

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

    public Transform enemyPool;

    public List<GameObject> enemies = new List<GameObject>();

    #endregion

    #region Private Variables

    private Animator _animator;

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

    public void ChangeState(States state)
    {
        _animator.SetTrigger(state.ToString());
    }

    public void StartWave()
    {
        StartCoroutine(SpawnHorde(LevelManager.Instance.GetCurrentWave()));
    }

    private IEnumerator SpawnHorde(Wave wave)
    {
        for(int i = 0; i < wave.hordes.Count; i++)
        {
            yield return StartCoroutine(SpawnEnemies(wave.hordes[i]));

            yield return new WaitForSeconds(wave.hordes[i].cooldown);
        }

        ChangeState(States.Wait);
    }

    private IEnumerator SpawnEnemies(Horde horde)
    {
        for(int i = 0; i < horde.enemyCount; i++)
        {
            Vector3 _randomPosition = _start[Random.Range(0, _start.Count)];

            GameObject _enemy = Instantiate(horde.enemy, _randomPosition, Quaternion.identity, enemyPool);

            enemies.Add(_enemy);

            yield return new WaitForSeconds(1f / horde.spawnRate);
        }
    }

    #endregion
}
