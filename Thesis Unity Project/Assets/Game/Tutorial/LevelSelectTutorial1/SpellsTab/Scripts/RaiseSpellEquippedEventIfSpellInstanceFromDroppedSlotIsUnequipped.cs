using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Spells;
using DLSU.WizardCode.UI.Slots;
using DLSU.WizardCode.Events;
using UnityEngine.EventSystems;

namespace DLSU.WizardCode.Tutorial.LevelSelectTutorial1.SpellsTab
{
    public class RaiseSpellEquippedEventIfSpellInstanceFromDroppedSlotIsUnequipped : MonoBehaviour
    {
        [SerializeField]
        private GameEvent onSpellEquipped;

        public void OnDrop(PointerEventData eventData)
        {
            GameObject dropped = eventData.pointerDrag;
            if (dropped != null)
            {
                SlotSpace slotSpaceOfDropped = dropped.GetComponent<SlotSpace>();
                if (slotSpaceOfDropped != null)
                {
                    if (!slotSpaceOfDropped.IsEmpty)
                    {
                        SpellInstanceHolder spellInstanceHolderOfDroppedSlot = slotSpaceOfDropped.Slot.GetComponent<SpellInstanceHolder>();
                        if (spellInstanceHolderOfDroppedSlot != null)
                        {
                            if (spellInstanceHolderOfDroppedSlot.SpellInstance != null)
                            {
                                if (!spellInstanceHolderOfDroppedSlot.SpellInstance.IsEquipped)
                                {
                                    onSpellEquipped.Raise();
                                }
                            }
                        }
                    }
                }
            }
        }
    }

}
