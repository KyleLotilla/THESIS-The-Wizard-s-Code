﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DLSU.WizardCode.Actions
{
    public class Action : MonoBehaviour
    {
        [SerializeField]
        private ActionType actionType;
        public ActionType ActionType
        {
            get
            {
                return actionType;
            }
            set
            {
                actionType = value;
            }
        }

        [SerializeField]
        private bool isExecuting = false;
        public bool IsExecuting
        {
            get
            {
                return isExecuting;
            }
        }

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

        protected virtual bool StartExecution()
        {
            return false;
        }

        public bool Execute()
        {
            isExecuting = StartExecution();
            if (isExecuting)
            {
                onActionExecutionStart?.Invoke();
            }
            return isExecuting;
        }

        public void EndExecution()
        {
            isExecuting = false;
            OnActionExecutionEnd?.Invoke();
        }
    }
}


