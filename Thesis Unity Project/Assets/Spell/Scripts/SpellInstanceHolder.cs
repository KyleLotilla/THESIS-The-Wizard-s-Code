using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.Spells
{
    public class SpellInstanceHolder : MonoBehaviour
    {
        [SerializeField]
        private SpellInstance spellInstance;
        public SpellInstance SpellInstance
        {
            get
            {
                return spellInstance;
            }
            set
            {
                spellInstance = value;
            }
        }
    }
}


