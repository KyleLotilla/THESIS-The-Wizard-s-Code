using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.UI.Views;

namespace DLSU.WizardCode.UI.Slots
{
    public class ControlDroppedIconViewInteractability : MonoBehaviour
    {
        private IconView currentDroppedIconView;

        public void OnSlotPrefabCreatedFromDropped(GameObject dropped, GameObject createdSlot)
        {
            IconView droppedIconView = dropped.GetComponent<IconView>();
            if (droppedIconView != null)
            {
                droppedIconView.Interactable = false;
                currentDroppedIconView = droppedIconView;
            }
        }

        public void OnSlotRemoved(GameObject removedSlot)
        {
            if (currentDroppedIconView != null)
            {
                currentDroppedIconView.Interactable = true;
                currentDroppedIconView = null;
            }
        }
    }

}
