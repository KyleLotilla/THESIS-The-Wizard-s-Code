using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DLSU.WizardCode.Events;

namespace DLSU.WizardCode.UI.Slots
{
    public class TransferSlotFromDroppedSlotSpaceToOwnSlotSpace : MonoBehaviour
    {
        [SerializeField]
        private SlotSpace slotSpace;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnDrop(PointerEventData eventData)
        {
            SlotSpace droppedSlotSpace = eventData.pointerDrag.GetComponent<SlotSpace>();
            if (droppedSlotSpace != null)
            {
                if (slotSpace.IsEmpty)
                {
                    GameObject tempSlot = droppedSlotSpace.Slot;
                    droppedSlotSpace.RemoveSlot();
                    slotSpace.Slot = tempSlot;
                }
                else
                {
                    slotSpace.SwapSlots(droppedSlotSpace);
                }
            }
        }
    }

}
