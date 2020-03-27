using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BTS.Manager.PathManager;

namespace Data.Characters.Enemy
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = PathManager.SOEnemyDataPath)]
    public class EnemyData : Data
    {
        [Header("Bio")]
        new public string name;
        [TextArea(5, 30)]
        public string description;
        [Range(0.1f, 5f)]
        public float size = 1f;

        [Header("Statistics")]
        public float life = 100f;

        public float movementSpeed = 2;
    }
}
