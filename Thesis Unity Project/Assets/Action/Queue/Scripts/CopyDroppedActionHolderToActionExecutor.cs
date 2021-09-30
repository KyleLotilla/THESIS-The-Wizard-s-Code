using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.Actions.Queue
{
    public class CopyDroppedActionHolderToActionExecutor : MonoBehaviour
    {
        [SerializeField]
        private ActionExecutor actionExecutor;
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
            ActionHolder droppedActionHolder = dropped.GetComponent<ActionHolder>();
            if (droppedActionHolder != null)
            {
                actionExecutor.ActionHolderObject = dropped;
            }
        }
    }

}

