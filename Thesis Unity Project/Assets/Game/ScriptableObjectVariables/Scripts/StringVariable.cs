using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.ScriptableObjectVariables
{
    [CreateAssetMenu(menuName = "StringVariable")]
    public class StringVariable : ScriptableObject
    {
        [SerializeField]
        private string defaultValue;
        [SerializeField]
        private string currentValue;

        public string Value
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
