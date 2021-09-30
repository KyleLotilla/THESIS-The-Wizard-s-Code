using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Util;
using UnityEngine.Events;

namespace DLSU.WizardCode.Actions
{
    public class ActionSequence : MonoBehaviour
    {
        [SerializeField]
        private List<ActionExecutor> actionExecutors;
        public List<ActionExecutor> ActionExecutors
        {
            get
            {
                return actionExecutors;
            }
            set
            {
                actionExecutors = value;
            }
        }

        [SerializeField]
        private UnityEvent onSequenceExecutionStart;
        [SerializeField]
        private UnityEvent onSequenceExecutionEnd;

        private int currentActionIndex = 0;

        public void StartExecution()
        {
            currentActionIndex = -1;
            onSequenceExecutionStart?.Invoke();
            ExecuteNextAction();
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

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
