using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.ScriptableObjectVariables
{
    [CreateAssetMenu(menuName = "IntVariable")]
    public class IntVariable : ScriptableObject
    {
        [SerializeField]
        private int defaultValue;
        [SerializeField]
        private int currentValue;
        public int Value
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

        public void Increment()
        {
            currentValue++;
        }
    }

}
