using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Events;
using DLSU.WizardCode.UI.Slots;

namespace DLSU.WizardCode.UI.ListViews
{
    public class CreateSlotForSlotSpaceListView : MonoBehaviour
    {
        [SerializeField]
        private GameObject slotPrefab;
        [SerializeField]
        private UnityEventTwoGameObjectOneNativeObject onSlotWithDataCreated;
        [SerializeField]
        private UnityEventTwoGameObjectParam onSlotWithNoDataCreated;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnItemViewWithDataCreated(GameObject itemView, object item)
        {
            SlotSpace slotSpace = itemView.GetComponent<SlotSpace>();
            if (slotSpace != null)
            {
                GameObject slot = Instantiate(slotPrefab);
                onSlotWithDataCreated?.Invoke(slot, itemView, item);
                slotSpace.Slot = slot;
            }
        }

        public void OnItemViewWithNoDataCreated(GameObject itemView)
        {
            SlotSpace slotSpace = itemView.GetComponent<SlotSpace>();
            if (slotSpace != null)
            {
                GameObject slot = Instantiate(slotPrefab);
                onSlotWithNoDataCreated?.Invoke(slot, itemView);
                slotSpace.Slot = itemView;
            }
        }
    }

}
