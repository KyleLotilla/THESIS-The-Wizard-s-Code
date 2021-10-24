using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.UI.Views;

namespace DLSU.WizardCode.Spells.UI.Inventory
{
    public class SetEquippedSpellsToListView : MonoBehaviour
    {
        [SerializeField]
        private SpellInventory spellInventory;
        [SerializeField]
        private ListView listView;

        public void SetEquippedSpells()
        {
            int maxEquipped = spellInventory.MaxEquipped;
            List<object> equippedSpells = spellInventory.EquippedSpellInstances.Select(x => (object)x).ToList();
            listView.CreateList(equippedSpells, maxEquipped);
        }
    }
}
