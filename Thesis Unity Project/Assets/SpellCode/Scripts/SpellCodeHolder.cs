using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Events;
using UnityEngine.Events;

namespace DLSU.WizardCode.SpellCodes
{
    public class SpellCodeHolder : MonoBehaviour
    {
        [SerializeField]
        private SpellCode spellCode;
        public SpellCode SpellCode
        {
            get
            {
                return spellCode;
            }
            set
            {
                spellCode = value;
                onSpellCodeChanged?.Invoke(spellCode);
            }
        }
        [SerializeField]
        private UnityEventOneSpellCodeParam onSpellCodeChanged;
        [SerializeField]
        private UnityEvent onNoSpellCodeSet; 
    }

}
