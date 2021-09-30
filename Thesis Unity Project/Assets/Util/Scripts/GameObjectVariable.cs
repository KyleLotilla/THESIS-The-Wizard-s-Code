using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.Util
{
    [CreateAssetMenu(menuName = "GameObject Variable")]
    public class GameObjectVariable : ScriptableObject
    {
        [SerializeField]
        private GameObject defaultValue;
        [SerializeField]
        private GameObject currentValue;

        public GameObject Value
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
