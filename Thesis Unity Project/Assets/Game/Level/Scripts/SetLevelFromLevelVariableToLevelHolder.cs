using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.ScriptableObjectVariables;

namespace DLSU.WizardCode.Levels
{
    public class SetLevelFromLevelVariableToLevelHolder : MonoBehaviour
    {
        [SerializeField]
        private LevelVariable levelVariable;
        [SerializeField]
        private LevelHolder levelHolder;

        public void SetLevel()
        {
            levelHolder.Level = levelVariable.Value;
        }
    }
}

