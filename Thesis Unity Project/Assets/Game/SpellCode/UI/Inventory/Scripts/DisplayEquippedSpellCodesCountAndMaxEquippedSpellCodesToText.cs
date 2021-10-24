using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DLSU.WizardCode.SpellCodes.UI.Inventory
{
    public class DisplayEquippedSpellCodesCountAndMaxEquippedSpellCodesToText : MonoBehaviour
    {
        [SerializeField]
        private SpellCodeInventory spellCodeInventory;
        [SerializeField]
        private Text text;

        public void DisplaySpellCodeEquippedCountAndMaxEquipped()
        {
            int equippedSpellCodesCount = spellCodeInventory.EquippedSpellCodesCount;
            int maxEquippedSpellCodes = spellCodeInventory.MaxEquipped;
            text.text = equippedSpellCodesCount.ToString() + " / " + maxEquippedSpellCodes.ToString();
        }
    }
}
