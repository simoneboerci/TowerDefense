using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SB.TextureConverter;

using Entity.Actor.Item.CameraScript;

namespace BTS.Manager.LevelManager
{
    public class LevelManager : Manager<LevelManager>
    {
        #region Public Variables

        [Header("Level Creation")]
        public ColorCode colorCode;
        public Transform levelParent;
        public List<Texture2D> levels;

        #endregion

        #region Privare Variables

        private int _currentLevelIndex = -1;
        List<GameObject> _objects = new List<GameObject>();

        #endregion

        #region Init

        private void Start()
        {
            LoadNextLevel();
        }

        #endregion

        #region Update

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                LoadNextLevel();
        }

        #endregion

        #region Public Methods

        public void LoadNextLevel()
        {
            //Check there is a level loaded
            if (_objects.Count > 0)
            {
                //Destroy all the objects in the current level
                foreach (GameObject obj in _objects)
                {
                    Destroy(obj);
                }
            }

            //Check if there is another level
            if(_currentLevelIndex + 1 < levels.Count)
            {
                _currentLevelIndex++;
            }
            else
            {
                _currentLevelIndex = 0;
            }

            //Load the next level
            List<GameObject> _convertedTexture = TextureConverter.FromTextureToObjects(levels[_currentLevelIndex], colorCode);

            //Create the level
            int _index = 0;

            for (int x = 0; x < levels[_currentLevelIndex].width; x++)
            {
                for (int y = 0; y < levels[_currentLevelIndex].height; y++)
                {
                    GameObject _obj = Instantiate(_convertedTexture[_index], new Vector3(x, 0, y), Quaternion.identity, levelParent);
                    _objects.Add(_obj);
                    _index++;
                }
            }

            //Update Camera
            Camera.main.GetComponent<CameraScript>().UpdateCamera();
        }

        public Texture2D GetCurrentLevel()
        {
            if (_currentLevelIndex < 0)
                return levels[0];

            return levels[_currentLevelIndex];
        }

        #endregion
    }
}
