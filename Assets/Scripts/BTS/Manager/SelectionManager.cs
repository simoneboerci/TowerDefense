using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTS.Manager.SelectionManager
{
    public class SelectionManager : Manager<SelectionManager>
    {
        #region Private Variables

        private Transform positionToBuild;
        public GameObject objectToBuild;

        #endregion

        public void SetPositionToBuild(Transform pos)
        {
            positionToBuild = pos;
            BuildManager.BuildManager.Instance.Build(objectToBuild, positionToBuild);
        }

        public void SetObjectToBuild(GameObject obj)
        {
            //objectToBuild = obj;
        }
    }
}
