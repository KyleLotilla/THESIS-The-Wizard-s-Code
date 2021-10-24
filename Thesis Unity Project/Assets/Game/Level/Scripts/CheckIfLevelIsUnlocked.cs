using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Events;
using DLSU.WizardCode.ScriptableObjectVariables;

namespace DLSU.WizardCode.Levels
{
    public class CheckIfLevelIsUnlocked : MonoBehaviour
    {
        [SerializeField]
        private IntVariable currentOverallStarsObtained;
        [SerializeField]
        private UnityEventOneLevelParam onLevelIsUnlocked;
        [SerializeField]
        private UnityEventOneLevelParam onLevelIsNotUnlocked;

        public void CheckIfUnlocked(Level level)
        {
            if (level != null)
            {
                if (currentOverallStarsObtained.Value >= level.OverallStarsNeededToUnlock)
                {
                    onLevelIsUnlocked?.Invoke(level);
                }
                else
                {
                    onLevelIsNotUnlocked?.Invoke(level);
                }
            }
        }
    }
}

