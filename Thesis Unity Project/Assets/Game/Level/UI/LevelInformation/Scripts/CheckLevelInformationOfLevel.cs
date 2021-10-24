using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Events;
using DLSU.WizardCode.ScriptableObjectVariables;

namespace DLSU.WizardCode.Levels.UI.LevelInformation
{
    public class CheckLevelInformationOfLevel : MonoBehaviour
    {
        [SerializeField]
        private LevelHolder levelHolder;
        [SerializeField]
        private LevelVariable selectedLevel;
        [SerializeField]
        private GameEvent onCheckLevelInformationOfSelectedLevel;

        public void CheckLevelInformation()
        {
            selectedLevel.Value = levelHolder.Level;
            onCheckLevelInformationOfSelectedLevel.Raise();
        }
    }

}
