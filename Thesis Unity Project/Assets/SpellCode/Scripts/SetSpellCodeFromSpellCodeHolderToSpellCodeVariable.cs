using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.ScriptableObjectVariables;

namespace DLSU.WizardCode.SpellCodes
{
    public class SetSpellCodeFromSpellCodeHolderToSpellCodeVariable : MonoBehaviour
    {
        [SerializeField]
        private SpellCodeVariable spellCodeVariable;
        [SerializeField]
        private SpellCodeHolder spellCodeHolder;

        public void SetSpellCodeVariable()
        {
            spellCodeVariable.Value = spellCodeHolder.SpellCode;
        }
    }

}
