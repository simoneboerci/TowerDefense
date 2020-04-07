using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Data.GraphicsData;
using Data.GraphicsData.MeshGeneratorData;

namespace Entity.Actor.Item.MeshGenerator
{
    public class MeshGenerator : Item
    {
        #region Public Variables

        [Header("Components")]
        public Transform mesh;

        [Header("Graphics")]
        public MeshGeneratorData data;

        #endregion

        #region Init

        private void Awake()
        {
            GenerateMesh();
        }

        #endregion

        #region Private Methods

        private void GenerateMesh()
        {
            //Prevent errors
            if (data.graphics.Count <= 0)
                return;

            //Get components
            MeshFilter _meshFilter = mesh.GetComponent<MeshFilter>();
            MeshRenderer _meshRenderer = mesh.GetComponent<MeshRenderer>();

            //Choose graphics data
            int _index = Random.Range(0, data.graphics.Count);

            //Get selected graphics data
            GraphicsData _graphicsData = data.graphics[_index];

            //Calculate scale
            float _scale = Random.Range(_graphicsData.minMeshSize, _graphicsData.maxMeshSize);
            //Set scale
            mesh.localScale = new Vector3(_scale, _scale, _scale);

            //Calculate rotation
            float _angle = Random.Range(0, 360f);
            //Set rotation
            mesh.Rotate(Vector3.up * _angle);

            //Set mesh
            _meshFilter.mesh = _graphicsData.mesh;

            //Set material
            _meshRenderer.material = _graphicsData.material;
        }

        #endregion
    }
}
