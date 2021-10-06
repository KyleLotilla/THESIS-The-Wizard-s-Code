using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DLSU.WizardCode.Events
{
    [Serializable]
    public class UnityEventOneGameObjectOneNativeObjectParam : UnityEvent<GameObject, object>
    {

    }

}
