using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Events;
using DLSU.WizardCode.ScriptableObjectVariables;
using DLSU.WizardCode.Levels;

namespace DLSU.WizardCode.Tutorial
{
    public class UnlockSpecificLevels : MonoBehaviour
    {
        [SerializeField]
        private BoolVariable shouldUnlockLevels;
        [SerializeField]
        private List<Level> levelsToUnlock;
        [SerializeField]
        private UnityEventOneLevelParam onLevelIsUnlocked;
        [SerializeField]
        private UnityEventOneLevelParam onLevelIsNotUnlocked;

        public void UnlockLevel(Level level)
        {
            if (shouldUnlockLevels.Value)
            {
                if (level != null)
                {
                    if (levelsToUnlock.Contains(level))
                    {
                        onLevelIsUnlocked?.Invoke(level);
                    }
                    else
                    {
                        onLevelIsNotUnlocked?.Invoke(level);
                    }
                }
            }
            else
            {
                onLevelIsNotUnlocked?.Invoke(level);
            }
        }
    }
}
