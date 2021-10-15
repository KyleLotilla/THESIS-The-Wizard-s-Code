using DLSU.WizardCode.ScriptableObjectVariables;
using UnityEngine;
using UnityEngine.Events;
namespace DLSU.WizardCode.Actions
{
    public class ActionExecutor : MonoBehaviour
    {
        [SerializeField]
        private ActionHolder actionHolder;
        [SerializeField]
        private GameObjectVariable currentExecutingActionObject;
        [SerializeField]
        private GameObjectVariable previousExecutedActionObject;
        [SerializeField]
        private UnityEvent onActionExecutionStart;
        public UnityEvent OnActionExecutionStart
        {
            get
            {
                return onActionExecutionStart;
            }
        }

        [SerializeField]
        private UnityEvent onActionExecutionEnd;

        public UnityEvent OnActionExecutionEnd
        {
            get
            {
                return onActionExecutionEnd;
            }
        }

        private bool isExecuting = false;
        public bool IsExecuting
        {
            get
            {
                return isExecuting;
            }
        }

        public Action Action
        {
            get
            {
                return actionHolder.Action;
            }
            set
            {
                actionHolder.Action = value;
            }
        }

        public bool Execute()
        {
            if (!isExecuting)
            {
                isExecuting = false;
                if (Action != null)
                {
                    isExecuting = Action.Execute();
                    if (isExecuting)
                    {
                        Action.OnActionExecutionEnd.AddListener(EndExecution);
                        currentExecutingActionObject.Value = Action.gameObject;
                        onActionExecutionStart?.Invoke();
                    }
                }
                return isExecuting;
            }
            else
            {
                return false;
            }
        }

        public void EndExecution()
        {
            if (isExecuting)
            {
                Action.OnActionExecutionEnd.RemoveListener(EndExecution);
                if (Action.IsExecuting)
                {
                    Action.EndExecution();
                }
                isExecuting = false;
                currentExecutingActionObject.Value = null;
                previousExecutedActionObject.Value = Action.gameObject;
                onActionExecutionEnd?.Invoke();
                previousExecutedActionObject.Value = null;
            }
        }
    }
}

