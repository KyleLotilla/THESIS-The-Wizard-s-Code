using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.ScriptableObjectVariables;

namespace DLSU.WizardCode.SpellCodes.UI.Edit
{
    public class SetCurrentSelectedSpellCodeToCurrentEditingSpellCode : MonoBehaviour
    {
        [SerializeField]
        private SpellCodeVariable currentSelectedSpellCode;
        [SerializeField]
        private SpellCodeVariable currentEditingSpellCode;

        public void SetCurrentSelectedSpellCode()
        {
            currentEditingSpellCode.Value = currentSelectedSpellCode.Value;
        }
    }
}
