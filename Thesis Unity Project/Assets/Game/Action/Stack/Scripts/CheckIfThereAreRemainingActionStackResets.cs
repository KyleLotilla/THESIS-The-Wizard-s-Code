using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DLSU.WizardCode.ScriptableObjectVariables;

namespace DLSU.WizardCode.Actions.Stack
{
    public class CheckIfThereAreRemainingActionStackResets : MonoBehaviour
    {
        [SerializeField]
        private IntVariable actionStackResetsCount;
        [SerializeField]
        private UnityEvent onHasResetsRemaining;
        [SerializeField]
        private UnityEvent onHasNoResetsRemaining;

        public void CheckRemainingResets()
        {
            if (actionStackResetsCount.Value > 0)
            {
                onHasResetsRemaining?.Invoke();
            }
            else
            {
                onHasNoResetsRemaining?.Invoke();
            }
        }
    }

}
