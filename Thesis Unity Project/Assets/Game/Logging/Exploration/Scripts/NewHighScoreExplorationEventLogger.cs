using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.Logging.Exploration
{
    public class NewHighScoreExplorationEventLogger : MonoBehaviour
    {
        [SerializeField]
        private ExplorationLogger explorationLogger;

        public void LogNewHighScoreExploration(int oldHighScore, int newHighScore)
        {
            XElement newHighScoreObtainedElement = new XElement("NewHighScoreObtained");
            newHighScoreObtainedElement.Add(new XElement("OldHighScore", oldHighScore));
            newHighScoreObtainedElement.Add(new XElement("NewHighScore", newHighScore));
            explorationLogger.AddExplorationLogEvent(newHighScoreObtainedElement);
        }
    }

}
