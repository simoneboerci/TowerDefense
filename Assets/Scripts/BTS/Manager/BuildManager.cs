using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTS.Manager.BuildManager
{
    public class BuildManager : Manager<BuildManager>
    {
        #region Public Methods

        public void Build(GameObject obj, Transform pos)
        {
            GameObject g = Instantiate(obj, pos);
            g.transform.position += Vector3.up * 0.08f;
        }

        public void Demolish(GameObject obj)
        {
            Destroy(obj);
        }

        public void Enable(GameObject obj)
        {
            obj.SetActive(true);
        }

        public void Disable(GameObject obj)
        {
            obj.SetActive(false);
        }

        #endregion
    }
}
