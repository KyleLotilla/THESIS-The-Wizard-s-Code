using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.Actions.Queue
{
    public class SetActionFromDroppedActionHolderToOwnActionHolder : MonoBehaviour
    {
        [SerializeField]
        private ActionHolder actionHolder;
        public void OnSlotPrefabCreatedFromDropped(GameObject dropped, GameObject createdSlot)
        {
            ActionHolder droppedActionHolder = dropped.GetComponent<ActionHolder>();
            if (droppedActionHolder != null)
            {
                actionHolder.Action = droppedActionHolder.Action;
            }
        }
    }

}

