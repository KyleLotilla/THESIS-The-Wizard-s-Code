using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.ScriptableObjectVariables;
using System;

namespace DLSU.WizardCode.Logging.Exploration
{
    public class SaveExplorationLogToDataPathWithLevelNameAndTimeStamp : MonoBehaviour
    {
        [SerializeField]
        private ExplorationLogger explorationLogger;
        [SerializeField]
        private LevelVariable currentLevel;

        public void SaveExplorationLog()
        {
            string levelName = currentLevel.Value.WorldNumber + "-" + currentLevel.Value.LevelNumber;
            SaveExplorationLog(levelName);
        }

        public void SaveExplorationLogOfTutorialLevel()
        {
            string levelName = currentLevel.Value.WorldNumber + "-" + currentLevel.Value.LevelNumber + "-Tutorial";
            SaveExplorationLog(levelName);
        }

        private void SaveExplorationLog(string levelName)
        {
            DateTime currentTime = DateTime.Now;
            string timeStamp = currentTime.ToString("yyyy-MM-ddTHH-mm-ss");
            string fileName = "Level" + levelName + "_" + timeStamp + ".xml";
            explorationLogger.SaveLogToDataPath(fileName);
        }
    }

}
