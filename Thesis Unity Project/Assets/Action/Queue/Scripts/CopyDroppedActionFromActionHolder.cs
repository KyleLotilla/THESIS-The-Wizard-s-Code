using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.Actions.Queue
{
    public class CopyDroppedActionFromActionHolder : MonoBehaviour
    {
        [SerializeField]
        private ActionHolder actionHolder;
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
                actionHolder.Action = droppedActionHolder.Action;
            }
        }
    }

}

