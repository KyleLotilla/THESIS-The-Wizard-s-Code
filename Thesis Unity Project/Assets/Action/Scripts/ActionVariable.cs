using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.Actions
{
    [CreateAssetMenu(menuName = "Spell/Action Variable")]
    public class ActionVariable : ScriptableObject
    {
        private Action currentValue;
        public Action Value
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

        public void OnEnable()
        {
            currentValue = null;
        }
    }
}
