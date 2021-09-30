using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.UI.Slots
{
    public class CopyIconSlotFromDroppedToInstantiatedIconSlot : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnPrefabInstantiated(GameObject dropped, GameObject instantiatedSlot)
        {
            IconSlot droppedIconSlot = dropped.GetComponent<IconSlot>();
            Debug.Assert(droppedIconSlot != null, name + ": No Icon Slot found in Dropped");
            IconSlot instantiatedIconSlot = instantiatedSlot.GetComponent<IconSlot>();
            Debug.Assert(instantiatedIconSlot != null, name + ": No Icon Slot found in Instantiated Slot");
            if (droppedIconSlot != null && instantiatedIconSlot != null)
            {
                instantiatedIconSlot.Icon.sprite = droppedIconSlot.Icon.sprite;
            }
        }
    }

}
