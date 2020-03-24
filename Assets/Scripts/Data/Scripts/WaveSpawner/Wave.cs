using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data.Wave
{
    [System.Serializable]
    public class Wave
    {
        public float delay;
        public List<Horde> hordes;
        public int repetition;      
    }
}
