using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.ScriptableObjectVariables;
using DLSU.WizardCode.Levels;
using System.Xml.Linq;

namespace DLSU.WizardCode.Logging.Exploration
{
    public class CurrentHighScoreExplorationLogger : MonoBehaviour
    {
        [SerializeField]
        private LevelVariable currentLevel;
        [SerializeField]
        private LevelProgressionDatabase levelProgressionDatabase;
        [SerializeField]
        private ExplorationLogger explorationLogger;

        public void LogCurrentHighScore()
        {
            int currentHighScore = 0;
            LevelProgression levelProgression = levelProgressionDatabase.GetLevelProgression(currentLevel.Value.LevelID);
            if (levelProgression != null)
            {
                currentHighScore = levelProgression.HighScore;
            }
            XElement currentHighScoreElement = new XElement("CurrentHighScore", currentHighScore);
            explorationLogger.AddLog(currentHighScoreElement);
        }
    }

}
