using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interfaces.IStateMachine
{
    public interface IStateMachine
    {
        #region Public Methods

        void ChangeState(string state);

        #endregion
    }
}
