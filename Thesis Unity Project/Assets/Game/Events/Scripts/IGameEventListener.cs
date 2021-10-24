using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.Events
{
    public interface IGameEventListener
    {
        void OnEventRaised();
    }
}
