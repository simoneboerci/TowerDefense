using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data.Wave
{
    [System.Serializable]
    public class Horde
    {
        public GameObject enemy;
        public int enemyCount;
        public float spawnRate;
        public float cooldown;
    }
}
