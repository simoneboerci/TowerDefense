using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTS.Manager.PathManager
{
    public class PathManager : Manager<PathManager>
    {
        protected const string SOPath = "ScriptableObjects/";
        protected const string SODataPath = SOPath + "Data/";

        public const string SOTurretDataPath = SODataPath + "TurretData";
        public const string SOEnemyDataPath = SODataPath + "EnemyData";
        public const string SOItemDataPath = SODataPath + "ItemData";

        public const string SOMeshGeneratorDataPath = SODataPath + "MeshGeneratorData";

        protected const string SOCameraTypePath = SOPath + "CameraType/";

        public const string SOTopDownCameraPath = SOCameraTypePath + "TopDownCameraType";
        public const string SOAngledCameraPath = SOCameraTypePath + "AngledCameraType";
    }
}
