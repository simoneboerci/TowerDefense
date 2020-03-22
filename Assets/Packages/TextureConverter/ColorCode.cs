using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SB.TextureConverter
{
    [CreateAssetMenu(fileName = "ColorCode", menuName = "ScriptableObjects/TextureConverter/ColorCode")]
    public class ColorCode : ScriptableObject
    {
        public List<ObjectReference> code;
    }
}
