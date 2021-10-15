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
                isExecuting = true;
                onSequenceExecutionStart?.Invoke();
                ExecuteNextAction();
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

        public void ExecuteNextAction()
        {
            if (isExecuting)
            {
                if (currentExecutingActionExecutorIndex >= 0 && currentExecutingActionExecutorIndex < actionExecutors.Count)
                {
                    actionExecutors[currentExecutingActionExecutorIndex].OnActionExecutionEnd.RemoveListener(ExecuteNextAction);
                }
                currentExecutingActionExecutorIndex++;
                bool hasExecutedAction = false;
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

                if (currentExecutingActionExecutorIndex >= actionExecutors.Count)
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

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
