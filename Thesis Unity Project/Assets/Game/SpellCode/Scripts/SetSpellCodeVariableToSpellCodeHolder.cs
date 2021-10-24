using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.ScriptableObjectVariables;

namespace DLSU.WizardCode.SpellCodes
{
    public class SetSpellCodeVariableToSpellCodeHolder : MonoBehaviour
    {
        [SerializeField]
        private SpellCodeVariable spellCodeVariable;
        [SerializeField]
        private SpellCodeHolder spellCodeHolder;

        public void SetSpellCodeVariable()
        {
            spellCodeHolder.SpellCode = spellCodeVariable.Value;
        }
    }
}

