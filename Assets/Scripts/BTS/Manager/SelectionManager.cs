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

        [Header("Prefabs: ")]
        [SerializeField]
        private GameObject _tile_I;
        [SerializeField]
        private GameObject _tile_T;
        [SerializeField]
        private GameObject _tile_L;

        private GameObject _objectToBuild;

        #endregion

        private void Start()
        {
            _objectToBuild = _tile_I;
        }

        public void SetPositionToBuild(Transform pos)
        {
            positionToBuild = pos;
            //GameObject _g = new GameObject();
            /*switch (_objectToBuild)
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
            }*/
            BuildManager.BuildManager.Instance.Build(_objectToBuild, positionToBuild);
        }

        public void SetObjectToBuild(GameObject obj)
        {
            _objectToBuild = obj;
        }
    }
    // passes an index of the list of gameobjects to build and then
    // set button text based on the name of the object passed to the function
}
