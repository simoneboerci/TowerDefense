using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BTS.Manager.PathManager;

namespace Data.EnemyData
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = PathManager.SOEnemyDataPath)]
    public class EnemyData : Data
    {
        public float movementSpeed;
        public float health;
    }
}
