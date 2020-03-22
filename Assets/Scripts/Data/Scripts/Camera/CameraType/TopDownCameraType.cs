using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BTS.Manager.PathManager;

using BTS.Manager.LevelManager;

namespace Data.Camera.CameraType {

    [CreateAssetMenu(fileName = "TopDownCameraType", menuName = PathManager.SOTopDownCameraPath)]
    public class TopDownCameraType : CameraType
    {
        #region Private Variables

        [SerializeField]
        [Header("Position")]
        [Tooltip("Change the tilt of the camera")]
        private float _xAngle = 40;

        #endregion

        #region Public methods

        public override void Setup(UnityEngine.Camera camera)
        {
            //Calculate the camera position without fov compensation
            Vector3 _rawPosition = CalculatePosition(CurrentLevel);

            //Apply fov compensation to the position
            position = CompensateFOV(_rawPosition, false, true, false);

            //Calculate the rotation
            rotation = CalculateRotation();
        }

        #endregion

        #region Private Methods

        #region Transform

        #region Position

        private Vector3 CalculatePosition(Texture2D currentLevel)
        {
            float _x = CalculateXPosition(currentLevel);
            float _z = CalculateZPosition(currentLevel);

            return new Vector3(_x, CalculateYPosition(_x, _z), _z);
        }

        #region Calculate Position

        private float CalculateXPosition(Texture2D currentLevel)
        {
            return currentLevel.width / 2f - 0.5f;
        }

        private float CalculateYPosition(float xPosition, float zPosition)
        {
            return xPosition * zPosition / 2f;
        }

        private float CalculateZPosition(Texture2D currentLevel)
        {
            return currentLevel.height / 2f - 0.5f;
        }

        #endregion

        #endregion

        #region Rotation

        private Vector3 CalculateRotation()
        {
            return new Vector3(_xAngle, 0, 0);
        }

        #endregion

        #endregion

        #endregion
    }
}