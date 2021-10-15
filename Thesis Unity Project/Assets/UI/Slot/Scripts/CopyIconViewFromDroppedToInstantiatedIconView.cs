using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.UI.Views;

namespace DLSU.WizardCode.UI.Slots
{
    public class CopyIconViewFromDroppedToInstantiatedIconView : MonoBehaviour
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
            IconView droppedIconView = dropped.GetComponent<IconView>();
            Debug.Assert(droppedIconView != null, name + ": No Icon Slot found in Dropped");
            IconView instantiatedIconSlot = instantiatedSlot.GetComponent<IconView>();
            Debug.Assert(instantiatedIconSlot != null, name + ": No Icon Slot found in Instantiated Slot");
            if (droppedIconView != null && instantiatedIconSlot != null)
            {
                instantiatedIconSlot.Icon.sprite = droppedIconView.Icon.sprite;
            }
        }
    }

}
