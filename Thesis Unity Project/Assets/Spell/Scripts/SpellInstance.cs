using System;
using UnityEngine;

namespace DLSU.WizardCode.Spells
{
    [Serializable]
    public class SpellInstance
    {
        public Spell spell;
        public bool isEquipped;
        public Sprite icon;
    }
}

