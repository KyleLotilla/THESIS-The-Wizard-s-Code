using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Exploration.Time;
using System.Xml.Linq;

namespace DLSU.WizardCode.Logging.Exploration
{
    public class ExplorationDurationLogger : MonoBehaviour
    {
        [SerializeField]
        private ExplorationTime explorationTime;
        [SerializeField]
        private ExplorationLogger explorationLogger;

        public void LogExplorationDuration()
        {
            TimeSpan explorationDuration = explorationTime.ExplorationDuration;
            string formattedExplorationDurationString = explorationDuration.Hours.ToString("D2") + ":" + explorationDuration.Minutes.ToString("D2") + ":" + explorationDuration.Seconds.ToString("D2");
            XElement explorationDurationElement = new XElement("ExplorationDuration", formattedExplorationDurationString);
            explorationLogger.AddLog(explorationDurationElement);
        }
    }

}
