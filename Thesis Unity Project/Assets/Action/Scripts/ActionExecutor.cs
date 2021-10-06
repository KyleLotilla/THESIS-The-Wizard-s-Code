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
        [SerializeField]
        private UnityEvent onActionExecutionEnd;

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
            bool isExecuting = false;
            if (Action != null)
            {
                isExecuting = Action.Execute();
                if (isExecuting)
                {
                    Action.OnActionExecutionEnd.AddListener(OnActionExecutionEnd);
                    currentExecutingActionObject.Value = Action.gameObject;
                    onActionExecutionStart?.Invoke();
                }
            }
            return isExecuting;
        }

        private void OnActionExecutionEnd()
        {
            Action.OnActionExecutionEnd.RemoveListener(OnActionExecutionEnd);
            currentExecutingActionObject.Value = null;
            previousExecutedActionObject.Value = Action.gameObject;
            onActionExecutionEnd?.Invoke();
            previousExecutedActionObject.Value = null;
        }
    }
}

