using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DLSU.WizardCode.Tags;

namespace DLSU.WizardCode.Events
{
    [Serializable]
    public class UnityEventOneTagOneGameObjectParam : UnityEvent<Tag, GameObject>
    {

    }
}


