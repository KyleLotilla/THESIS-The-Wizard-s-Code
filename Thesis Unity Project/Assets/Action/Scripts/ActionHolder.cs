using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DLSU.WizardCode.Events;

namespace DLSU.WizardCode.Actions
{
    public class ActionHolder : MonoBehaviour
    {
        [SerializeField]
        private Action action;
        public Action Action
        {
            get
            {
                return action;
            }
            set
            {
                action = value;
                if (action != null)
                {
                    onActionChanged?.Invoke(action);
                }
                else
                {
                    onNoActionSet?.Invoke();
                }
            }
        }
        [SerializeField]
        private UnityEventOneActionParam onActionChanged;
        [SerializeField]
        private UnityEvent onNoActionSet;

        public void SetActionToNull()
        {
            Action = null;
        }
    }

}
