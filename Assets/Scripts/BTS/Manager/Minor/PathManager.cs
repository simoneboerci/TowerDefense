using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTS.Manager.PathManager
{
    public class PathManager : Manager<PathManager>
    {
        /// <summary>
        /// This class containes all the paths for the creation of the scriptable objects
        /// </summary>

        protected const string SOPath = "ScriptableObjects/";
        protected const string SODataPath = SOPath + "Data/";

        public const string SOMeshGeneratorDataPath = SODataPath + "MeshGeneratorData";

        protected const string SOCameraTypePath = SOPath + "CameraType/";

        public const string SOTopDownCameraPath = SOCameraTypePath + "TopDownCameraType";
        public const string SOAngledCameraPath = SOCameraTypePath + "AngledCameraType";

        public const string SOLevelPath = SOPath + "Level";

        protected const string SOCharacterDataPath = SODataPath + "CharacterData/";

        public const string SOEnemyDataPath = SOCharacterDataPath + "EnemyData";
    }
}
