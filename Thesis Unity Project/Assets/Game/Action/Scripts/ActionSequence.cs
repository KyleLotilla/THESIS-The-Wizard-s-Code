using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DLSU.WizardCode.Actions
{
    public class ActionSequence : MonoBehaviour
    {
        [SerializeField]
        private List<ActionExecutor> actionExecutors;
        public IEnumerable<ActionExecutor> ActionExecutors
        {
            get
            {
                return actionExecutors;
            }
        }
        [SerializeField]
        private UnityEvent onSequenceExecutionStart;
        [SerializeField]
        private UnityEvent onSequenceExecutionEnd;

        private bool isExecuting = false;
        public bool IsExecuting
        {
            get
            {
                return isExecuting;
            }
        }
        private int currentExecutingActionExecutorIndex = 0;

        private void Awake()
        {
            if (actionExecutors != null)
            {
                actionExecutors = new List<ActionExecutor>();
            }
        }

        public void StartExecution()
        {
            if (!isExecuting)
            {
                currentExecutingActionExecutorIndex = -1;
                isExecuting = TryToExecuteNextAction();
                if (isExecuting)
                {
                    onSequenceExecutionStart?.Invoke();
                }
            }
        }

        public void StartExecution(List<Action> actions)
        {
            if (!isExecuting)
            {
                for (int i = 0; i < actions.Count && i < actionExecutors.Count; i++)
                {
                    actionExecutors[i].Action = actions[i];
                }
                StartExecution();
            }
        }

        private bool TryToExecuteNextAction()
        {
            bool hasExecutedAction = false;
            currentExecutingActionExecutorIndex++;
            while (currentExecutingActionExecutorIndex < actionExecutors.Count && !hasExecutedAction)
            {
                hasExecutedAction = actionExecutors[currentExecutingActionExecutorIndex].Execute();
                if (hasExecutedAction)
                {
                    actionExecutors[currentExecutingActionExecutorIndex].OnActionExecutionEnd.AddListener(ExecuteNextAction);
                }
                else
                {
                    currentExecutingActionExecutorIndex++;
                }
            }
            return hasExecutedAction;
        }

        private void ExecuteNextAction()
        {
            if (isExecuting)
            {
                if (currentExecutingActionExecutorIndex >= 0 && currentExecutingActionExecutorIndex < actionExecutors.Count)
                {
                    actionExecutors[currentExecutingActionExecutorIndex].OnActionExecutionEnd.RemoveListener(ExecuteNextAction);
                }
                bool hasExecutedAction = TryToExecuteNextAction();
                if (!hasExecutedAction)
                {
                    EndExecution();
                }
            }
        }

        public void EndExecution()
        {
            if (isExecuting)
            {
                isExecuting = false;
                if (currentExecutingActionExecutorIndex >= 0 && currentExecutingActionExecutorIndex < actionExecutors.Count)
                {
                    actionExecutors[currentExecutingActionExecutorIndex].OnActionExecutionEnd.RemoveListener(ExecuteNextAction);
                    actionExecutors[currentExecutingActionExecutorIndex].EndExecution();
                }
                onSequenceExecutionEnd?.Invoke();
            }
        }

        public void AddActionExecutor(ActionExecutor actionExecutor)
        {
            actionExecutors.Add(actionExecutor);
        }

        public void ClearActionExecutors()
        {
            actionExecutors.Clear();
        }
    }

}
