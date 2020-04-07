using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entity.Actor.Item.GridTile
{
    public class GridTile : Item
    {
        #region Private Variables

        private bool isEmpty = true;

        #endregion

        #region Public Methods

        public void SetEmpty(bool value)
        {
            isEmpty = value;
        }

        public bool GetEmpty()
        {
            return isEmpty;
        }

        #endregion
    }
}
