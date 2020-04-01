using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BTS.Manager.GameManager;
using BTS.Manager.LevelManager;

using Data.Characters.Enemy;

namespace Entity.Actor.Character.Enemy
{
    [RequireComponent(typeof(Collider))]
    public class Enemy : Character
    {
        #region Private Variables

        [SerializeField]
        private MeshRenderer _meshRenderer;
        private Color _defaultColor;

        [SerializeField]
        private EnemyData _data;

        private float _life;

        #region Path

        private Vector3 _target;
        private Vector3 _targetDirection;
        private List<Vector3> _targets = new List<Vector3>();

        #endregion

        #endregion

        #region Init

        private void Awake()
        {
            transform.localScale = new Vector3(_data.size, _data.size, _data.size);

            _defaultColor = _meshRenderer.material.color;

            foreach(Vector3 target in LevelManager.Instance.path)
            {
                _targets.Add(target);
            }

            Debug.Log(_targets[0]);

            _life = _data.life;
        }

        #endregion

        #region Update

        private void Update()
        {
            if(_targetDirection == Vector3.zero || IsOnTarget())
            {
                ChangeTarget();
            }
            else
            {
                transform.Translate(_targetDirection.normalized * _data.movementSpeed * Time.deltaTime);
            }

            if (_life <= 0f)
                Die();
        }

        #endregion

        #region Public Methods

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

        #region Private Methods

        private bool IsOnTarget()
        {
            if (transform.position.x <= _target.x + 0.1f && transform.position.x > _target.x - 0.1f && transform.position.z <= _target.z + 0.1f && transform.position.z > _target.z - 0.1f)
            {
                return true;
            }

            return false;
        }

        private void ChangeTarget()
        {
            float _minDistanceToTarget = float.PositiveInfinity;
            Vector3 _tempTarget = Vector3.zero;

            for(int i = 0; i < LevelManager.Instance.GetEnd().Count; i++)
            {
                if(VerifyTarget(_minDistanceToTarget, _tempTarget, LevelManager.Instance.GetEnd()[i]))
                {
                    _tempTarget = LevelManager.Instance.GetEnd()[i];
                    _minDistanceToTarget = Vector3.Distance(transform.position, LevelManager.Instance.GetEnd()[i]);
                }
            }

            for(int i = 0; i < _targets.Count; i++)
            {
                if(VerifyTarget(_minDistanceToTarget, _tempTarget, _targets[i]))
                {
                    _tempTarget = _targets[i];
                    _minDistanceToTarget = Vector3.Distance(transform.position, _targets[i]);
                }
            }

            SetTarget(_tempTarget);
        }

        private bool VerifyTarget(float minDistanceToTarget, Vector3 currentTarget, Vector3 target)
        {
            if (minDistanceToTarget > Vector3.Distance(transform.position, target))
            {
                if (currentTarget != target)
                {
                    return true;
                }
            }

            return false;
        }

        private void SetTarget(Vector3 tempTarget)
        {
            _target = tempTarget;
            _targets.Remove(_target);
            _targetDirection = _target - transform.position;
        }

        private void Die()
        {
            GameManager.Instance.waveSpawner.enemies.Remove(this.gameObject);
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
