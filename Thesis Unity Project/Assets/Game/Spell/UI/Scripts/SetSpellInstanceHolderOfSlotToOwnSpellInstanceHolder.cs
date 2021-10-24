using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.Spells.UI
{
    public class SetSpellInstanceHolderOfSlotToOwnSpellInstanceHolder : MonoBehaviour
    {
        [SerializeField]
        private SpellInstanceHolder spellInstanceHolder;

        public void OnSlotAdded(GameObject slot)
        {
            SpellInstanceHolder spellInstanceHolderOfSlot = slot.GetComponent<SpellInstanceHolder>();
            if (spellInstanceHolderOfSlot != null)
            {
                spellInstanceHolder.SpellInstance = spellInstanceHolderOfSlot.SpellInstance;
            }
        }

        public void OnSlotRemoved(GameObject removedSlot)
        {
            spellInstanceHolder.SetToNull();
        }
    }

}
