using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Entity.Component.Controller;

namespace Entity.Actor
{
    public abstract class Actor : Entity
    {
        internal Controller _controller;

        private void Awake()
        {
            _controller = GetComponent<Controller>();
        }
    }
}
