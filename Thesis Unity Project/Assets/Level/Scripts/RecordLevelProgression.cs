using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Events;
using DLSU.WizardCode.ScriptableObjectVariables;

namespace DLSU.WizardCode.Levels
{
    public class RecordLevelProgression : MonoBehaviour
    {
        [SerializeField]
        private LevelVariable currentLevel;
        [SerializeField]
        private LevelProgressionDatabase levelProgressionDatabase;
        [SerializeField]
        private UnityEventOneLevelProgressionParam onNewLevelProgressionCreated;
        [SerializeField]
        private UnityEventOneLevelProgressionParam onLevelProgressionUpdated;

        public void RecordProgression()
        {
            int levelID = currentLevel.Value.LevelID;
            LevelProgression currentLevelProgression = levelProgressionDatabase.GetLevelProgression(levelID);
            if (currentLevelProgression == null)
            {
                currentLevelProgression = new LevelProgression();
                currentLevelProgression.LevelID = levelID;
                onNewLevelProgressionCreated?.Invoke(currentLevelProgression);
                levelProgressionDatabase.AddProgression(currentLevelProgression);
            }
            else
            {
                onLevelProgressionUpdated?.Invoke(currentLevelProgression);
            }
        }
    }

}
