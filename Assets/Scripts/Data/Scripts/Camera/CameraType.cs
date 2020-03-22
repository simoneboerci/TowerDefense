using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BTS.Manager.LevelManager;

namespace Data.Camera.CameraType
{
    public abstract class CameraType : Data
    {
        #region Public Variables

        [HideInInspector]
        public Vector3 position;
        [HideInInspector]
        public Vector3 rotation;

        [Header("Camera")]
        [Tooltip("Change the field of view of the camera")]
        public float fov = 60;

        #endregion

        #region Private Variables

        [SerializeField]
        [Tooltip("Compensate the fov by correcting the position of the camera")]
        protected float _fovCorrection = 0.55f;

        #region Properties

        protected Texture2D CurrentLevel
        {
            get
            {
                return LevelManager.Instance.GetCurrentLevel();
            }
        }

        #endregion

        #endregion

        #region Public Methods

        #region Abstract Methods

        public abstract void Setup(UnityEngine.Camera camera);

        #endregion

        #endregion

        #region Private Methods

        protected Vector3 CompensateFOV(Vector3 position, bool XCorrection, bool YCorrection, bool ZCorrection)
        {
            if (XCorrection)
                position.x = CalculateAdjustedCoordinate(position.x);
            if (YCorrection)
                position.y = CalculateAdjustedCoordinate(position.y);
            if (ZCorrection)
                position.z = CalculateAdjustedCoordinate(position.z);

            return position;
        }

        private float CalculateAdjustedCoordinate(float coord)
        {
            return coord / _fovCorrection;
        }

        #endregion
    }
}
