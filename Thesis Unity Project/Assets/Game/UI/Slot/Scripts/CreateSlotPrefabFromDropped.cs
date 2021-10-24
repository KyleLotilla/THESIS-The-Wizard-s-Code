using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DLSU.WizardCode.Events;

namespace DLSU.WizardCode.UI.Slots
{
    public class CreateSlotPrefabFromDropped : MonoBehaviour
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


