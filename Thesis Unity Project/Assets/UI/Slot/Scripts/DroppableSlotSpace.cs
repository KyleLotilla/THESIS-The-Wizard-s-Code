using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DLSU.WizardCode.UI.Slots
{
    public class DroppableSlotSpace : MonoBehaviour
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
                    slotSpace.Slot = droppedSlotSpace.Slot;
                    droppedSlotSpace.RemoveSlot();
                }
                else
                {
                    slotSpace.SwapSlots(droppedSlotSpace);
                }
            }
        }
    }

}
