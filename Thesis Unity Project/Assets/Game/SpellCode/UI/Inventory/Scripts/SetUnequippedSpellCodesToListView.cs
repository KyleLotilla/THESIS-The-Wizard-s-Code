using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.UI.Views;

namespace DLSU.WizardCode.SpellCodes.UI.Inventory
{
    public class SetUnequippedSpellCodesToListView : MonoBehaviour
    {
        [SerializeField]
        private SpellCodeInventory spellCodeInventory;
        [SerializeField]
        private ListView listView;

        public void SetUnequippedSpells()
        {
            List<object> unequippedSpells = spellCodeInventory.UnequippedSpellCodes.Select(x => (object)x).ToList();
            listView.CreateList(unequippedSpells);
        }
    }

}
