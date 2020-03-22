using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BTS.Manager.PathManager;

namespace Data.Wave
{
    [CreateAssetMenu(fileName = "Wave", menuName = PathManager.SOWavePath)]
    public class Wave : Data
    {
        public GameObject enemy;
        public int count;
        public float spawnRate;
        public float cooldownTimer;
    }
}
