using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.Spells.UI.Inventory
{
    public class EquipSpellInstanceOnSlotAdded : MonoBehaviour
    {
        [SerializeField]
        private SpellInventory spellInventory;

        public void OnSlotAdded(GameObject slot)
        {
            SpellInstanceHolder spellInstanceHolderOfSlot = slot.GetComponent<SpellInstanceHolder>();
            if (spellInstanceHolderOfSlot != null)
            {
                SpellInstance spellInstanceOfSlot = spellInstanceHolderOfSlot.SpellInstance;
                if (spellInstanceOfSlot != null)
                {
                    if (!spellInstanceOfSlot.IsEquipped)
                    {
                        spellInventory.EquipSpellInstance(spellInstanceOfSlot);
                    }
                }
            }
        }
    }
}
