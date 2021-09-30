using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.UI.Slots
{
    public class ParentSlotWtihSlotSpace : MonoBehaviour
    {
        [SerializeField]
        private SlotSpace slotSpace;

        public void OnSlotAdded(GameObject slot)
        {
            slot.transform.SetParent(slotSpace.transform);
        }

        public void OnSlotSwapped(GameObject oldSlot, GameObject slot)
        {
            if (slot.transform.parent != slotSpace.transform)
            {
                slot.transform.SetParent(slotSpace.transform);
            }
        }

        public void OnSlotRemoved(GameObject removedSlot)
        {
            removedSlot.transform.SetParent(null);
        }
    }

}
