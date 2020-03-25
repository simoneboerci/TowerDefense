using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data.GraphicsData
{
    [System.Serializable]
    public struct GraphicsData
    {
        [Header("Mesh")]
        public Mesh mesh;
        [Range(0.01f, 1f)]
        public float minMeshSize;
        [Range(0.01f, 1f)]
        public float maxMeshSize;

        [Header("Material")]
        public Material material;
    }
}
