using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BTS.Manager.GameManager;
using BTS.Manager.LevelManager;

using Data.Characters.Enemy;

using Interfaces.IStateMachine;

namespace Entity.Actor.Character.Enemy
{
    [RequireComponent(typeof(Animator),typeof(Collider))]
    public class Enemy : Character, IStateMachine
    {
        #region Public Variables

        public enum States
        {
            Checking,
            Patrol,
        }

        public States currentState;

        #endregion

        #region Private Variables

        private Animator _animator;

        [SerializeField]
        private MeshRenderer _meshRenderer;
        private Color _defaultColor;

        [SerializeField]
        private EnemyData _data;

        private float _life;

        #region Path

        private Vector3 _target;
        private List<Vector3> _targets = new List<Vector3>();
        private Quaternion _targetRotation;

        #endregion

        #endregion

        #region Init

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        #endregion

        #region Update

        private void Update()
        {    
            /*if (_life <= 0f)
                Die();*/
        }

        #endregion

        #region Public Methods

        #region Setup

        public void SetLife()
        {
            _life = _data.life;
        }

        public void SetDefaultColor()
        {
            _defaultColor = _meshRenderer.material.color;
        }

        #endregion

        #region Getters

        public EnemyData GetData() => _data;

        public List<Vector3> GetTargets() => _targets;

        public Vector3 GetCurrentTarget() => _target;

        #endregion

        #region Setters

        public void SetTargetPosition(Vector3 target) => _target = target;

        public void SetTargetRotation(Quaternion rotation) => _targetRotation = rotation;

        #endregion

        #region Targets

        public void AddTarget(Vector3 target)
        {
            if (!_targets.Contains(target))
                _targets.Add(target);
            else
                Debug.LogErrorFormat("{0} target is already in the list targets for the enemy {1}", target, transform.name);
        }

        public void RemoveTarget(Vector3 target)
        {
            if(_targets.Contains(target))
                _targets.Remove(target);
            else
                Debug.LogErrorFormat("No {0} target in the list of targets for the enemy {1}", target, transform.name);
        }

        public void LookAtTarget()
        {
            StartCoroutine(Rotate());
        }

        #endregion

        #region Damage

        public void GetDamage(float damage)
        {
            StartCoroutine(ColorTransition());

            _life -= damage;
        }

        IEnumerator ColorTransition()
        {
            _meshRenderer.material.color = Color.yellow;

            yield return new WaitForSeconds(0.2f);

            _meshRenderer.material.color = _defaultColor;
        }

        #endregion

        public void ChangeState(string state)
        {
            _animator.SetTrigger(state);
        }

        #endregion

        #region Private Methods

        IEnumerator Rotate()
        {
            while (transform.rotation != _targetRotation)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, _targetRotation, _data.rotationSpeed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }

            yield return null;
        }

        private void Die()
        {
            GameManager.Instance.waveSpawner.enemies.Remove(this.gameObject);
            GameManager.Instance.DecreaseLives();
            Destroy(this.gameObject);  
        }

        #region Unity

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("End"))
            {
                Die();
            }
        }

        #endregion

        #endregion
    }
}
