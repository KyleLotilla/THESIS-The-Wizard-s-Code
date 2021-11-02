using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace DLSU.WizardCode.UI
{
    public class CheckIfInputFieldIsBelowMinimumLength : MonoBehaviour
    {
        [SerializeField]
        private InputField inputField;
        [SerializeField]
        private int minimumLength;
        [SerializeField]
        private UnityEvent onIsEqualToOrGreaterThanLength;
        [SerializeField]
        private UnityEvent onBelowMinimumLength;

        public void CheckInputFieldLength()
        {
            if (inputField.text.Length >= minimumLength)
            {
                onIsEqualToOrGreaterThanLength?.Invoke();
            }
            else
            {
                onBelowMinimumLength?.Invoke();
            }
        }
    }

}
