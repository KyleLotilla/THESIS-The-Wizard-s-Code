using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Events;
using DLSU.WizardCode.UI.Slots;

namespace DLSU.WizardCode.UI.Views
{
    public class CreateSlotForSlotSpaceListItemView : MonoBehaviour
    {
        [SerializeField]
        private SlotSpace slotSpace;
        [SerializeField]
        private GameObject slotPrefab;
        [SerializeField]
        private UnityEventOneGameObjectOneNativeObjectParam onSlotWithDataCreated;
        public void OnItemViewWithDataCreated(object data)
        {
            GameObject slot = Instantiate(slotPrefab);
            onSlotWithDataCreated?.Invoke(slot, data);
            slotSpace.Slot = slot;
        }
    }

}
