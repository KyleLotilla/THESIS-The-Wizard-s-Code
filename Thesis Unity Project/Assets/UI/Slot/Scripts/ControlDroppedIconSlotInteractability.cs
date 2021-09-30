using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.UI.Slots
{
    public class ControlDroppedIconSlotInteractability : MonoBehaviour
    {
        private IconSlot currentDroppedSlot;
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
            if (droppedIconSlot != null)
            {
                droppedIconSlot.Interactable = false;
                currentDroppedSlot = droppedIconSlot;
            }
        }

        public void OnSlotRemoved(GameObject removedSlot)
        {
            if (currentDroppedSlot != null)
            {
                currentDroppedSlot.Interactable = true;
                currentDroppedSlot = null;
            }
        }
    }

}
