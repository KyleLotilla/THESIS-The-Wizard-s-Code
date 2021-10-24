using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.ScriptableObjectVariables;

namespace DLSU.WizardCode.SpellCodes.UI.Inventory
{
    public class RemoveCurrentSelectedSpellCode : MonoBehaviour
    {
        [SerializeField]
        private SpellCodeVariable currentSelectedSpellCode;
        [SerializeField]
        private SpellCodeInventory spellCodeInventory;

        public void RemoveSpellCode()
        {
            if (currentSelectedSpellCode.Value != null)
            {
                if (currentSelectedSpellCode.Value.IsEquipped)
                {
                    spellCodeInventory.UnequipSpellCode(currentSelectedSpellCode.Value);
                }
                spellCodeInventory.RemoveUnequippedSpellCode(currentSelectedSpellCode.Value);
                currentSelectedSpellCode.Value = null;
            }
        }
    }

}
