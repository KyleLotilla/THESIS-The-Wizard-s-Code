using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.ScriptableObjectVariables;

namespace DLSU.WizardCode.SpellCodes.UI.Edit
{
    public class AddNewlyCreatedSpellCodeToSpellCodeInventory : MonoBehaviour
    {
        [SerializeField]
        private BoolVariable IsCreatingNewSpellCode;
        [SerializeField]
        private SpellCodeVariable currentEditingSpellCode;
        [SerializeField]
        private SpellCodeInventory spellCodeInventory;

        public void AddNewlyCreatedSpellCode()
        {
            if (IsCreatingNewSpellCode.Value)
            {
                spellCodeInventory.AddUnequippedSpellCode(currentEditingSpellCode.Value);
            }
        }
    }

}
