using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Spells;

namespace DLSU.WizardCode.ScriptableObjectVariables
{
    [CreateAssetMenu(menuName = "Spell/SpellInstanceListVariable")]
    public class SpellInstanceListVariable : ScriptableObject
    {
        [SerializeField]
        private List<SpellInstance> defaultValue;
        [SerializeField]
        private List<SpellInstance> currentValue;
        public List<SpellInstance> Value
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

        public void Clear()
        {
            currentValue.Clear();
        }
    }
}

