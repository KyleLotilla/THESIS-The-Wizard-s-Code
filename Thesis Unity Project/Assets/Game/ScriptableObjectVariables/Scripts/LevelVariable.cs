using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Levels;

namespace DLSU.WizardCode.ScriptableObjectVariables
{
    [CreateAssetMenu(menuName = "Level/LevelVariable")]
    public class LevelVariable : ScriptableObject
    {
        [SerializeField]
        private Level defaultValue;
        [SerializeField]
        private Level currentValue;
        public Level Value
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
