using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DLSU.WizardCode.SpellCodes.UI.Edit
{
    public abstract class EdittedSpellCodeStateValidator : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent onSpellCodeStateValid;
        [SerializeField]
        private UnityEvent onSpellCodeStateInvalid;

        protected abstract bool Validate();

        public bool ValidateSpellCodeState()
        {
            bool isValidState = Validate();
            if (isValidState)
            {
                onSpellCodeStateValid?.Invoke();
            }
            else
            {
                onSpellCodeStateInvalid?.Invoke();
            }
            return isValidState;
        }
    }
}
