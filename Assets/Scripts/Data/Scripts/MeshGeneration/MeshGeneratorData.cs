using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BTS.Manager.PathManager;

namespace Data.GraphicsData.MeshGeneratorData
{
    [CreateAssetMenu(fileName = "MeshGeneratorData", menuName = PathManager.SOMeshGeneratorDataPath)]
    public class MeshGeneratorData : Data
    {
        public List<GraphicsData> graphics;
    }
}
