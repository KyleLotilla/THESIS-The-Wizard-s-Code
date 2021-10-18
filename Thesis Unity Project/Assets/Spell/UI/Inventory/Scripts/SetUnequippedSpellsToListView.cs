using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.UI.Views;

namespace DLSU.WizardCode.Spells.UI.Inventory
{
    public class SetUnequippedSpellsToListView : MonoBehaviour
    {
        [SerializeField]
        private SpellInventory spellInventory;
        [SerializeField]
        private ListView listView;
        [SerializeField]
        private int slotCount;
        public void SetUnequippedSpells()
        {
            List<object> unequippedSpells = spellInventory.UnequippedSpellInstances.Select(x => (object)x).ToList();
            listView.CreateList(unequippedSpells, slotCount);
        }
    }
}
