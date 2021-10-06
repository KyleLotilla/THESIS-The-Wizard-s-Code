using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DLSU.WizardCode.Events;

namespace DLSU.WizardCode.UI.Slots
{
    public class InstantiateSlotPrefabFromDropped : MonoBehaviour
    {
        [SerializeField]
        private SlotSpace slotSpace;
        [SerializeField]
        private GameObject slotPrefab;
        [SerializeField]
        private UnityEventTwoGameObjectParam onPrefabInstantiated;
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnDrop(PointerEventData eventData)
        {
            if (slotSpace.IsEmpty)
            {
                GameObject dropped = eventData.pointerDrag;
                GameObject instantiatedSlot = Instantiate(slotPrefab);
                Debug.Assert(instantiatedSlot != null, name + ": Slot Prefab not Instantiated");
                if (instantiatedSlot != null)
                {
                    onPrefabInstantiated?.Invoke(dropped, instantiatedSlot);
                    slotSpace.Slot = instantiatedSlot;
                }
            }
        }
    }
}


