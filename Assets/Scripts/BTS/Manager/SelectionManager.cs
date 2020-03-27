using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTS.Manager.SelectionManager
{
    public class SelectionManager : Manager<SelectionManager>
    {
        #region Private Variables

        private Transform positionToBuild;
        //public GameObject objectToBuild;
        private enum Tiles
        {
            Tile_I,
            Tile_T,
            Tile_L,
        }
        [SerializeField]
        private Tiles _objectToBuild;
        [Header("Prefabs: ")]
        [SerializeField]
        private GameObject _tile_I;
        [SerializeField]
        private GameObject _tile_T;
        [SerializeField]
        private GameObject _tile_L;

        #endregion

        public void SetPositionToBuild(Transform pos)
        {
            positionToBuild = pos;
            GameObject _g = new GameObject();
            switch (_objectToBuild)
            {
                case Tiles.Tile_I:
                    _g = _tile_I;
                    break;
                case Tiles.Tile_T:
                    _g = _tile_T;
                    break;
                case Tiles.Tile_L:
                    _g = _tile_L;
                    break;
                default:
                    break;
            }
            BuildManager.BuildManager.Instance.Build(_g, positionToBuild);
        }

        private void Build()
        {

        }

        public void SetObjectToBuild(GameObject obj)
        {
            //objectToBuild = obj;
        }
    }
}
