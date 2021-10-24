using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Spells;
using UnityEngine.Events;

namespace DLSU.WizardCode.Events
{
    [Serializable]
    public class UnityEventOneSpellInstanceListParam : UnityEvent<List<SpellInstance>>
    {

    }
}
