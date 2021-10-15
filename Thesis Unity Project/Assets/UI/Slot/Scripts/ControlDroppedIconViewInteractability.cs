using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.UI.Views;

namespace DLSU.WizardCode.UI.Slots
{
    public class ControlDroppedIconViewInteractability : MonoBehaviour
    {
        private IconView currentDroppedIconView;
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
