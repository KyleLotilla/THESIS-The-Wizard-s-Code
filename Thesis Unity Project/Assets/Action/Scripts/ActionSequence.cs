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

        private int currentActionIndex = 0;

        private void Awake()
        {
            if (actionExecutors != null)
            {
                actionExecutors = new List<ActionExecutor>();
            }
        }

        public void StartExecution()
        {
            currentActionIndex = -1;
            onSequenceExecutionStart?.Invoke();
            ExecuteNextAction();
        }

        public void StartExecution(List<Action> actions)
        {
            for (int i = 0; i < actions.Count && i < actionExecutors.Count; i++)
            {
                actionExecutors[i].Action = actions[i];
            }
            StartExecution();
        }

        public void ExecuteNextAction()
        {
            currentActionIndex++;
            bool hasExecutedAction = false;
            while (currentActionIndex < actionExecutors.Count && !hasExecutedAction)
            {
                hasExecutedAction = actionExecutors[currentActionIndex].Execute();
                if (!hasExecutedAction)
                {
                    currentActionIndex++;
                }
            }

            if (currentActionIndex >= actionExecutors.Count)
            {
                EndExecution();
            }
        }

        public void EndExecution()
        {
            onSequenceExecutionEnd?.Invoke();
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
