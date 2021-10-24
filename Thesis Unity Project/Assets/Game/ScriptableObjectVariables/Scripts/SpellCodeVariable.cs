using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.SpellCodes;

namespace DLSU.WizardCode.ScriptableObjectVariables
{
    [CreateAssetMenu(menuName = "SpellCode/SpellCodeVariable")]
    public class SpellCodeVariable : ScriptableObject
    {
        [SerializeField]
        private SpellCode defaultValue;
        [SerializeField]
        private SpellCode currentValue;
        public SpellCode Value
        {
            get
            {
                return currentValue;
            }
            set
            {
                currentValue = value;
            }
        }

        private void OnEnable()
        {
            currentValue = defaultValue;
        }

        public void SetToNull()
        {
            currentValue = null;
        }
    }
}
