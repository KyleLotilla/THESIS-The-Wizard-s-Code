using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.ScriptableObjectVariables;

namespace DLSU.WizardCode.SpellCodes.UI.Edit
{
    public class CreateNewSpellCodeForCurrentEditingSpellCode : MonoBehaviour
    {
        [SerializeField]
        private SpellCodeVariable currentEditingSpellCode;

        public void CreateNewSpellCode()
        {
            SpellCode spellCode = new SpellCode();
            spellCode.Name = "New SpellCode";
            currentEditingSpellCode.Value = spellCode;
        }
    }

}
