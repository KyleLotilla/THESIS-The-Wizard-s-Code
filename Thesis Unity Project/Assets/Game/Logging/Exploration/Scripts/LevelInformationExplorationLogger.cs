using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.ScriptableObjectVariables;
using DLSU.WizardCode.Obstacles;
using System.Xml.Linq;

namespace DLSU.WizardCode.Logging.Exploration
{
    public class LevelInformationExplorationLogger : MonoBehaviour
    {
        [SerializeField]
        private ExplorationLogger explorationLogger;
        [SerializeField]
        private LevelVariable currentLevel;

        public void LogLevelInformation()
        {
            if (currentLevel.Value != null)
            {
                string levelName = currentLevel.Value.WorldNumber + "-" + currentLevel.Value.LevelNumber;
                LogLevelName(levelName);
                LogLevelObstacles();
                LogMovesRequirementForStars();
            }
        }

        public void LogTutorialLevelInformation()
        {
            if (currentLevel.Value != null)
            {
                string levelName = currentLevel.Value.WorldNumber + "-" + currentLevel.Value.LevelNumber + "-Tutorial";
                LogLevelName(levelName);
                LogLevelObstacles();
                LogMovesRequirementForStars();
            }
        }

        private void LogLevelName(string levelName)
        {
            XElement levelNameElement = new XElement("Level", levelName);
            explorationLogger.AddLog(levelNameElement);
        }

        private void LogLevelObstacles()
        {
            XElement obstaclesElement = new XElement("Obstacles");
            foreach (KeyValuePair<Obstacle, int> obstacleCount in currentLevel.Value.ObstalceCounts)
            {
                XElement obstacleElement = new XElement("Obstacle");
                XElement obstacleNameElement = new XElement("Name", obstacleCount.Key.ObstacleName);
                obstacleElement.Add(obstacleNameElement);
                XElement obstalceCountElement = new XElement("Count", obstacleCount.Value);
                obstacleElement.Add(obstalceCountElement);
                obstaclesElement.Add(obstacleElement);
            }
            explorationLogger.AddLog(obstaclesElement);
        }

        private void LogMovesRequirementForStars()
        {
            XElement movesRequirementsForStarsElement = new XElement("MovesRequirementsForStars");
            int movesRequirementForTwoStars = currentLevel.Value.GetMovesRequirement(2);
            movesRequirementsForStarsElement.Add(new XElement("TwoStars", movesRequirementForTwoStars));
            int movesRequirementForThreeStars = currentLevel.Value.GetMovesRequirement(3);
            movesRequirementsForStarsElement.Add(new XElement("ThreeStars", movesRequirementForThreeStars));
            explorationLogger.AddLog(movesRequirementsForStarsElement);
        }
    }

}
