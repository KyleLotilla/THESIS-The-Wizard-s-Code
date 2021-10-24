using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.UI.Views;

namespace DLSU.WizardCode.SpellCodes.UI.Inventory
{
    public class SetEquippedSpellCodesToListView : MonoBehaviour
    {
        [SerializeField]
        private SpellCodeInventory spellCodeInventory;
        [SerializeField]
        private ListView listView;

        public void SetEquippedSpells()
        {
            List<object> equippedSpells = spellCodeInventory.EquippedSpellCodes.Select(x => (object)x).ToList();
            listView.CreateList(equippedSpells);
        }
    }

}
