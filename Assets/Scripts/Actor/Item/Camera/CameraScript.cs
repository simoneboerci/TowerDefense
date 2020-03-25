using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entity.Actor.Item.CameraScript
{
    [RequireComponent(typeof(Camera))]
    public class CameraScript : Item
    {
        #region Private Variables

        [Header("Setup")]
        [SerializeField]
        private Vector3 _startingPosition;
        [SerializeField]
        private Vector3 _startingRotation;
        [SerializeField]
        [Tooltip("Choose whether to use position coordinates as a camera spawn point or as a vector offset calculated based on the type of camera")]
        private bool _usePositionAsOffset;
        [SerializeField]
        [Tooltip("Choose whether to use rotation coordinates as a camera spawn point or as a vector offset calculated based on the type of camera")]
        private bool _useRotationAsOffset;
        [Header("Camera Types")]
        [SerializeField]
        private Data.Camera.CameraType.CameraType _topDownCamera;
        [SerializeField]
        private Data.Camera.CameraType.CameraType _angledCamera;

        [Header("Effects")]
        [SerializeField]
        private float _transitionSpeed;

        private Camera _camera;   

        private Data.Camera.CameraType.CameraType _currentCameraType;

        #endregion

        #region Init

        private void Awake()
        {
            _camera = GetComponent<Camera>();
            _currentCameraType = _topDownCamera;
        }

        private void Start()
        {
            UpdateCamera();
            SetStartingTransform();
        }

        #endregion

        #region Update

        private void FixedUpdate()
        {
            //Make the transition between two camera states
            transform.position = Vector3.Lerp(transform.position, _currentCameraType.position, _transitionSpeed * Time.fixedDeltaTime);
            transform.rotation = Quaternion.Euler(Vector3.Lerp(transform.rotation.eulerAngles, _currentCameraType.rotation, _transitionSpeed * Time.fixedDeltaTime));
            _camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, _currentCameraType.fov, _transitionSpeed * Time.fixedDeltaTime);
        }

        private void Update()
        {
            #region TEMP
            //Change camera mode by pressing a key
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (_currentCameraType == _topDownCamera)
                    _currentCameraType = _angledCamera;
                else if (_currentCameraType == _angledCamera)
                    _currentCameraType = _topDownCamera;

                UpdateCamera();
            }
            #endregion
        }

        #endregion

        #region Public Methods

        public void UpdateCamera()
        {
            _currentCameraType.Setup(_camera);
        }

        #endregion

        #region Private Methods

        #region Set Starting Transform

        private void SetStartingTransform()
        {
             SetStartingPosition();
             SetStartingRotation();
        }

        private void SetStartingPosition()
        {
            //Prevent errors
            if(_startingPosition == Vector3.zero)
            {
                _startingPosition = _currentCameraType.position;
                _usePositionAsOffset = false;
            }

            //Set position
            if (_usePositionAsOffset)
                transform.position = _currentCameraType.position + _startingPosition;
            else
                transform.position = _startingPosition;
        }

        private void SetStartingRotation()
        {
            //Prevent errors
            if(_startingRotation == Vector3.zero)
            {
                _startingRotation = _currentCameraType.rotation;
                _useRotationAsOffset = false;
            }

            //Set rotation
            if (_useRotationAsOffset)
                transform.rotation = Quaternion.Euler(_currentCameraType.rotation + _startingRotation);
            else
                transform.rotation = Quaternion.Euler(_startingRotation);
        }

        #endregion

        #endregion
    }
}
