using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BTS.Manager.PathManager;

namespace Data.Level {
    [CreateAssetMenu(fileName = "Level", menuName = PathManager.SOLevelPath)]
    public class Level : Data
    {
        public Texture2D map;
        public List<Wave.Wave> waves;
    }
}
