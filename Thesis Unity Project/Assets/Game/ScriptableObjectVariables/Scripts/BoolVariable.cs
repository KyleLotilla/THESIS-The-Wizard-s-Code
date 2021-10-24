using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.ScriptableObjectVariables
{
    [CreateAssetMenu(menuName = "BoolVariable")]
    public class BoolVariable : ScriptableObject
    {
        [SerializeField]
        private bool defaultValue;
        [SerializeField]
        private bool currentValue;
        public bool Value
        {
            get
            {
                return currentValue;
            }
            set
            {
                currentValue = value;
            }
        }

        private void OnEnable()
        {
            currentValue = defaultValue;
        }
    }

}
