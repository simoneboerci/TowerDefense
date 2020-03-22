using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Entity.Component.BehaviourComponent;

namespace Entity.Component.Controller
{
    public abstract class Controller : CustomComponent
    {
        internal BehaviourComponent.BehaviourComponent _behaviourComponent;

        private void Awake()
        {
            _behaviourComponent = GetComponent<BehaviourComponent.BehaviourComponent>();
        }
    }
}
