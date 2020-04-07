using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entity.Actor.Character.Enemy
{
    public abstract class Enemy : Character
    {
        public virtual void Die()
        {
            Destroy(this.gameObject);
        }
    }
}