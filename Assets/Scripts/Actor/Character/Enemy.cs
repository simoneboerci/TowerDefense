using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BTS.Manager.GameManager;

using Data.Characters.Enemy;

namespace Entity.Actor.Character.Enemy
{
    public class Enemy : Character
    {
        #region Private Variables

        [SerializeField]
        private MeshRenderer _meshRenderer;
        private Color _defaultColor;

        [SerializeField]
        private EnemyData _data;

        private float _life;

        #endregion

        #region Init

        private void Awake()
        {
            transform.localScale = new Vector3(_data.size, _data.size, _data.size);

            _defaultColor = _meshRenderer.material.color;

            _life = _data.life;
        }

        #endregion

        #region Update

        private void Update()
        {
            transform.Translate(transform.right * _data.movementSpeed * Time.deltaTime);

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

        private void Die()
        {
            GameManager.Instance.waveSpawner.enemies.Remove(this.gameObject);
            Destroy(this.gameObject);  
        }

        #endregion
    }
}
