using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data.Wave
{
    [System.Serializable]
    public struct Wave
    {
        public float delay;
        public List<Horde> hordes;
    }
}
