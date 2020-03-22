using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BTS.Manager.PathManager;

using BTS.Manager.LevelManager;

namespace Data.Camera.CameraType {

    [CreateAssetMenu(fileName = "AngledCameraType", menuName = PathManager.SOAngledCameraPath)]
    public class AngledCameraType : CameraType
    {
        #region Private Variables

        [SerializeField]
        [Header("Position")]
        [Tooltip("Change the tilt of the camera")]
        private float _xAngle = 40;

        #endregion

        #region Public Methods

        public override void Setup(UnityEngine.Camera camera)
        {
            //Calculate the camera position without fov compensation
            Vector3 _rawPostion = CalculatePosition(CurrentLevel);

            //Apply fov compensation to the position
            position = CompensateFOV(_rawPostion, false, true, true);        

            //Calculate the rotation
            rotation = CalculateRotation();
        }

        #endregion

        #region Private Methods

        #region Transform

        #region Position

        private Vector3 CalculatePosition(Texture2D currentLevel)
        {
            return new Vector3(CalculateXPosition(currentLevel), CalculateYPosition(currentLevel), CalculateZPosition(currentLevel));
        }

        #region Calculate Position

        private float CalculateXPosition(Texture2D currentLevel)
        {
            return currentLevel.width / 2f - 0.5f;
        }

        private float CalculateYPosition(Texture2D currentLevel)
        {
            return currentLevel.height / 2f;
        }

        private float CalculateZPosition(Texture2D currentLevel)
        {
            return -currentLevel.height / 2f + 0.7f;
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
