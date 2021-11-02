using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Obstacles;
using DLSU.WizardCode.Exploration.Time;
using System.Xml.Linq;

namespace DLSU.WizardCode.Logging.Exploration
{
    public class ObstacleOvercameExplorationEventLogger : MonoBehaviour
    {
        [SerializeField]
        private ExplorationLogger explorationLogger;
        [SerializeField]
        private ExplorationTime explorationTime;
        [SerializeField]
        private ObstacleHolder obstalceHolder;

        public void LogObstacleOvercame()
        {
            if (obstalceHolder.Obstacle != null)
            {
                XElement obstacleOvercame = new XElement("ObstacleOvercame");
                string formattedTimeStampString = explorationTime.FormattedTimeStampString;
                obstacleOvercame.Add(new XElement("TimeStamp", formattedTimeStampString));
                obstacleOvercame.Add(new XElement("Obstacle", obstalceHolder.Obstacle.ObstacleName));
                explorationLogger.AddExplorationLogEvent(obstacleOvercame);
            }
        }
    }

}
