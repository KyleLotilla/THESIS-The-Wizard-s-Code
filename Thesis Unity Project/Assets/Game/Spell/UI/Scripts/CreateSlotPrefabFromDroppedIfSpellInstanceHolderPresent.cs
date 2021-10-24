using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DLSU.WizardCode.UI.Slots;
using DLSU.WizardCode.Events;

namespace DLSU.WizardCode.Spells.UI
{
    public class CreateSlotPrefabFromDroppedIfSpellInstanceHolderPresent : MonoBehaviour
    {
        [SerializeField]
        private SlotSpace slotSpace;
        [SerializeField]
        private GameObject slotPrefab;
        [SerializeField]
        private UnityEventTwoGameObjectParam onSlotPrefabCreatedFromDropped;

        public void OnDrop(PointerEventData eventData)
        {
            if (slotSpace.IsEmpty)
            {
                GameObject dropped = eventData.pointerDrag;
                SpellInstanceHolder spellInstanceHolderOfDropped = dropped.GetComponent<SpellInstanceHolder>();
                if (spellInstanceHolderOfDropped != null)
                {
                    GameObject createdSlot = Instantiate(slotPrefab);
                    Debug.Assert(createdSlot != null, name + ": Slot Prefab not Instantiated");
                    if (createdSlot != null)
                    {
                        onSlotPrefabCreatedFromDropped?.Invoke(dropped, createdSlot);
                        slotSpace.Slot = createdSlot;
                    }
                }
            }
        }
    }

}
