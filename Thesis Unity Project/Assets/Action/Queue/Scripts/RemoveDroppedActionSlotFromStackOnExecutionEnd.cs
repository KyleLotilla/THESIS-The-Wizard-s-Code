using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.ScriptableObjectVariables;
using DLSU.WizardCode.Actions.Stack;

namespace DLSU.WizardCode.Actions.Queue
{
    public class RemoveDroppedActionSlotFromStackOnExecutionEnd : MonoBehaviour
    {
        [SerializeField]
        private GameObjectVariable actionStackObject;
        private GameObject droppedActionSlotObject;
        private ActionStack actionStack;

        // Start is called before the first frame update
        void Start()
        {
            Debug.Assert(actionStackObject.Value != null, name + ": Action Stack GameObjectVariable not initialized");
            if (actionStackObject.Value != null)
            {
                actionStack = actionStackObject.Value.GetComponent<ActionStack>();
                Debug.Assert(actionStack != null, name + ": Action Stack Object has no Action Stack compoenent");
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnPrefabInstantiated(GameObject dropped, GameObject instantiatedSlot)
        {
            if (actionStack.HasGameObjectAsSpawnedAction(dropped))
            {
                droppedActionSlotObject = dropped;
            }
        }

        public void OnExecutionEnd()
        {
            if (droppedActionSlotObject != null)
            {
                actionStack.RemoveSpawnedActionFromStack(droppedActionSlotObject);
                droppedActionSlotObject = null;
            }
        }

        public void SetDroppedActionSlotObjectToNull()
        {
            droppedActionSlotObject = null;
        }
    }

}
