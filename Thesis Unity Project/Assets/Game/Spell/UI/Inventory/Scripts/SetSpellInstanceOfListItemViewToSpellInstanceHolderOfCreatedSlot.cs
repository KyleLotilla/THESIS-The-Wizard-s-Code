using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.Spells.UI.Inventory
{
    public class SetSpellInstanceOfListItemViewToSpellInstanceHolderOfCreatedSlot : MonoBehaviour
    {
        public void OnSlotWithDataCreated(GameObject slotObject, object data)
        {
            SpellInstance spellInstance = data as SpellInstance;
            if (spellInstance != null)
            {
                SpellInstanceHolder spellInstanceHolderOfSlot = slotObject.GetComponent<SpellInstanceHolder>();
                if (spellInstanceHolderOfSlot != null)
                {
                    spellInstanceHolderOfSlot.SpellInstance = spellInstance;
                }
            }
        }
    }

}

