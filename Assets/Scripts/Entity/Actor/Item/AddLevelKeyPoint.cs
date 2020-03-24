using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BTS.Manager.LevelManager;

namespace Entity.Actor.Item.LevelCreation
{
    public class AddLevelKeyPoint : Item
    {
        #region Private Variables

        [SerializeField]
        private LevelManager.KeyPoints _keyPoint;

        #endregion

        #region Init

        private void Awake()
        {
            LevelManager.Instance.AddKeyPoint(transform.position, _keyPoint);
        }

        #endregion
    }
}
