using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DLSU.WizardCode.Events;

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
                if (spellInstance != null)
                {
                    onSpellInstanceChanged?.Invoke(spellInstance);
                }
                else
                {
                    onNoSpellInstanceSet?.Invoke();
                }
            }
        }
        [SerializeField]
        private UnityEventOneSpellInstanceParam onSpellInstanceChanged;
        [SerializeField]
        private UnityEvent onNoSpellInstanceSet;

        public void SetToNull()
        {
            SpellInstance = null;
        }
    }
}


