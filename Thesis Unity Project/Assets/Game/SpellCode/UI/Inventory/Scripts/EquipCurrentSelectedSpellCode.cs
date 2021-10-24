using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.ScriptableObjectVariables;

namespace DLSU.WizardCode.SpellCodes.UI.Inventory
{
    public class EquipCurrentSelectedSpellCode : MonoBehaviour
    {
        [SerializeField]
        private SpellCodeInventory spellCodeInventory;
        [SerializeField]
        private SpellCodeVariable currentSelectedSpellCode;

        public void EquipSpellCode()
        {
            if (currentSelectedSpellCode.Value != null)
            {
                if (!currentSelectedSpellCode.Value.IsEquipped)
                {
                    spellCodeInventory.EquipSpellCode(currentSelectedSpellCode.Value);
                }
            }
        }
    }
}
