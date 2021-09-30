using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Util;
using UnityEngine.Events;
namespace DLSU.WizardCode.Actions
{
    public class ActionExecutor : MonoBehaviour
    {
        [SerializeField]
        private GameObject actionHolderObject;
        public GameObject ActionHolderObject
        {
            get
            {
                return actionHolderObject;
            }
            set
            {
                actionHolderObject = value;
                if (actionHolderObject != null)
                {
                    ActionHolder actionHolder = actionHolderObject.GetComponent<ActionHolder>();
                    Debug.Assert(actionHolder != null, name + ": Action Holder not found in Action Object");
                    if (actionHolder != null)
                    {
                        action = actionHolder.Action;
                        Debug.Assert(action != null, name + ": No Action found in Action Holder");
                    }
                }
                else
                {
                    action = null;
                }
            }
        }
        private Action action;
        [SerializeField]
        private GameObjectVariable currentExecutingActionHolderObject;
        [SerializeField]
        private GameObjectVariable previousExecutedActionHolderObject;
        [SerializeField]
        private bool destroyActionHolderOnExecutionEnd;
        [SerializeField]
        private UnityEvent onActionExecutionStart;
        [SerializeField]
        private UnityEvent onActionExecutionEnd;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public bool Execute()
        {
            bool isExecuting = false;
            if (actionHolderObject != null)
            {
                isExecuting = action.Execute();
                if (isExecuting)
                {
                    action.OnActionExecutionEnd.AddListener(OnActionExecutionEnd);
                    currentExecutingActionHolderObject.Value = actionHolderObject;
                    onActionExecutionStart?.Invoke();
                }
            }
            return isExecuting;
        }

        private void OnActionExecutionEnd()
        {
            action.OnActionExecutionEnd.RemoveListener(OnActionExecutionEnd);
            currentExecutingActionHolderObject.Value = null;
            previousExecutedActionHolderObject.Value = actionHolderObject;
            onActionExecutionEnd?.Invoke();
            if (destroyActionHolderOnExecutionEnd)
            {
                Destroy(previousExecutedActionHolderObject.Value);
                ActionHolderObject = null;
            }
            previousExecutedActionHolderObject.Value = null;
        }

        public void RemoveAction()
        {
            ActionHolderObject = null;
        }
    }
}

