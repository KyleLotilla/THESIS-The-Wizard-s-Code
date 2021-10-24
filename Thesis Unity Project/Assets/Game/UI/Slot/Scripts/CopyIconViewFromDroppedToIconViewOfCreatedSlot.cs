using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.UI.Views;

namespace DLSU.WizardCode.UI.Slots
{
    public class CopyIconViewFromDroppedToIconViewOfCreatedSlot : MonoBehaviour
    {
        public void OnSlotPrefabCreatedFromDropped(GameObject dropped, GameObject createdSlot)
        {
            IconView droppedIconView = dropped.GetComponent<IconView>();
            Debug.Assert(droppedIconView != null, name + ": No Icon Slot found in Dropped");
            IconView iconViewOfSlot = createdSlot.GetComponent<IconView>();
            Debug.Assert(iconViewOfSlot != null, name + ": No Icon Slot found in Instantiated Slot");
            if (droppedIconView != null && iconViewOfSlot != null)
            {
                iconViewOfSlot.Icon.sprite = droppedIconView.Icon.sprite;
            }
        }
    }

}
