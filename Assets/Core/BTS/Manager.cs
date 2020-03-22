using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTS.Manager
{
    public abstract class Manager<T> : BTS
    {
        #region Instance

        private static Manager<T> instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                    instance = FindObjectOfType<Manager<T>>();

                return (T)(instance as object);
            }
        }

        #endregion
    }
}
