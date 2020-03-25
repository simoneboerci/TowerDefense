using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Data.LevelCreation;
using Data.Wave;

using SB.TextureConverter;

using Entity.Actor.Item.CameraScript;

namespace BTS.Manager.LevelManager
{
    public class LevelManager : Manager<LevelManager>
    {
        #region Public Variables

        public enum KeyPoints
        {
            Start,
            End,
        }

        [Header("Level Creation")]
        public ColorCode colorCode;
        public Transform levelParent;

        [Header("Gameplay")]
        public List<Level> levels;

        #endregion

        #region Private Variables

        private int _currentLevelIndex = -1;
        private int _currentWaveIndex = 0;

        //List that contains every grid tile spawned
        List<GameObject> _objects = new List<GameObject>();

        //List that contains every possible spawn point for the enemies
        private List<Vector3> _start = new List<Vector3>();
        //List that contains every possible arrival point for enemies
        private List<Vector3> _end = new List<Vector3>();

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
            #region TEMP
            //Change level when a key is pressed
            if (Input.GetKeyDown(KeyCode.Space) && _currentLevelIndex + 1 < levels.Count)
            {
                LoadNextLevel();
            }

            #endregion
        }

        #endregion

        #region Public Methods

        #region Level Generation

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

                //Reset the start and the end of the level
                _start = new List<Vector3>();
                _end = new List<Vector3>();
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
            List<GameObject> _convertedTexture = TextureConverter.FromTextureToObjects(levels[_currentLevelIndex].map, colorCode);

            //Create the level
            int _index = 0;

            for (int x = 0; x < levels[_currentLevelIndex].map.width; x++)
            {
                for (int y = 0; y < levels[_currentLevelIndex].map.height; y++)
                {
                    GameObject _obj = Instantiate(_convertedTexture[_index], new Vector3(x, 0, y), Quaternion.identity, levelParent);
                    _objects.Add(_obj);
                    _index++;
                }
            }

            //Update Camera
            Camera.main.GetComponent<CameraScript>().UpdateCamera();
        }

        public void AddKeyPoint(Vector3 position, KeyPoints keyPoint) 
        {
            switch (keyPoint)
            {
                case KeyPoints.Start:
                    _start.Add(position);
                    break;
                case KeyPoints.End:
                    _end.Add(position);
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Getters

        public Level GetCurrentLevel()
        {
            if (_currentLevelIndex < 0)
                return levels[0];

            return levels[_currentLevelIndex];
        }

        public Texture2D GetCurrentMap()
        {     
            return GetCurrentLevel().map;
        }

        public Wave GetCurrentWave()
        {
            return GetCurrentLevel().waves[_currentWaveIndex];
        }

        public List<Vector3> GetStart()
        {
            return _start;
        }

        public List<Vector3> GetEnd()
        {
            return _end;
        }

        #endregion

        public bool NextWave()
        {
            //If there is another wave start the next one and return true
            if (_currentWaveIndex + 1 < GetCurrentLevel().waves.Count)
            {
                _currentWaveIndex++;
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
