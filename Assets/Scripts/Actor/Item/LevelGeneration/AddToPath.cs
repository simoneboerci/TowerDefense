using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BTS.Manager.LevelManager;

namespace Entity.Actor.Item.LevelCreation
{
    public class AddToPath : MonoBehaviour
    {
        #region Init

        private void Awake()
        {
            if (Random.Range(0, 1f) > 0.8f)
            {
                LevelManager.Instance.path.Add(this.transform.position);
                GetComponentInChildren<MeshRenderer>().material.color = Color.cyan;
            }
        }

        #endregion
    }
}
