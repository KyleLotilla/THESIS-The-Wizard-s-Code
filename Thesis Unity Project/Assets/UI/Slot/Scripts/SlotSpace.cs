using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Events;
using UnityEngine.Events;

namespace DLSU.WizardCode.UI.Slots
{
    public class SlotSpace : MonoBehaviour
    {
        [SerializeField]
        private GameObject slot;
        public GameObject Slot
        {
            get
            {
                return slot;
            }
            set
            {
                GameObject oldSlot = slot;
                slot = value;
                if (slot == null)
                {
                    if (oldSlot != null)
                    {
                        onSlotRemoved?.Invoke(oldSlot);
                        if (destroySlotOnRemove)
                        {
                            Destroy(oldSlot);
                        }
                    }
                }
                else if (oldSlot != null)
                {
                    onSlotSwapped?.Invoke(oldSlot, slot);
                }
                else
                {
                    onSlotAdded?.Invoke(slot);
                }
            }
        }

        public bool IsEmpty
        {
            get
            {
                return slot == null;
            }
        }

        [SerializeField]
        private bool isSwappable = false;

        public bool IsSwappable
        {
            get
            {
                return isSwappable;
            }
            set
            {
                isSwappable = value;
            }
        }

        [SerializeField]
        private bool destroySlotOnRemove = false;

        [SerializeField]
        private UnityEventOneGameObjectParam onSlotAdded;
        [SerializeField]
        private UnityEventTwoGameObjectParam onSlotSwapped;
        [SerializeField]
        private UnityEventOneGameObjectParam onSlotRemoved; 

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void RemoveSlot()
        {
            Slot = null;
        }

        public void SwapSlots(SlotSpace otherSpace)
        {
            if (IsSwappable && otherSpace.IsSwappable)
            {
                GameObject temp = Slot;
                Slot = otherSpace.Slot;
                otherSpace.Slot = temp;
            }
        }
    }

}
