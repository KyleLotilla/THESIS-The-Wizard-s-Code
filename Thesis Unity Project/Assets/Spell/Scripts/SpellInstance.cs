using System;
using UnityEngine;

namespace DLSU.WizardCode.Spells
{
    [Serializable]
    public class SpellInstance
    {
        [SerializeField]
        private Spell spell;
        public Spell Spell
        {
            get
            {
                return spell;
            }
            set
            {
                spell = value;
            }
        }
        [SerializeField]
        private bool isEquipped;
        public bool IsEquipped
        {
            get
            {
                return isEquipped;
            }
            set
            {
                isEquipped = value;
            }
        }

        [SerializeField]
        private Sprite icon;
        public Sprite Icon
        {
            get
            {
                return icon;
            }
            set
            {
                icon = value;
            }
        }
    }
}

