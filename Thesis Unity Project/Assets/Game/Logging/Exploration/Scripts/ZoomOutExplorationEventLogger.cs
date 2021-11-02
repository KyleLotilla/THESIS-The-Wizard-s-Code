using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml.Linq;
using DLSU.WizardCode.Exploration.Time;

namespace DLSU.WizardCode.Logging.Exploration
{
    public class ZoomOutExplorationEventLogger : MonoBehaviour
    {
        [SerializeField]
        private ExplorationLogger explorationLogger;
        [SerializeField]
        private ExplorationTime explorationTime;

        private TimeSpan zoomOutTimeStamp;
        private TimeSpan zoomInTimeStamp;

        public void LogZoomOut()
        {
            zoomOutTimeStamp = explorationTime.TimeStamp;
        }

        public void LogZoomIn()
        {
            zoomInTimeStamp = explorationTime.TimeStamp;
            XElement zoomOutElement = new XElement("ZoomOut");
            string zoomOutFormattedTimeStampString = GetFormattedTimeStampString(zoomOutTimeStamp);
            zoomOutElement.Add(new XElement("ZoomOutTimeStamp", zoomOutFormattedTimeStampString));
            string zoomInFormattedTimeStampString = GetFormattedTimeStampString(zoomInTimeStamp);
            zoomOutElement.Add(new XElement("ZoomInTimeStamp", zoomInFormattedTimeStampString));
            explorationLogger.AddExplorationLogEvent(zoomOutElement);
        }

        private string GetFormattedTimeStampString(TimeSpan timeStamp)
        {
            string formattedTimeStampString = timeStamp.Hours.ToString("D2") + ":" + timeStamp.Minutes.ToString("D2") + ":" + timeStamp.Seconds.ToString("D2");
            return formattedTimeStampString;
        }
    }
}
