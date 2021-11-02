using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;

namespace DLSU.WizardCode.Logging.Exploration
{
    public class ExplorationCompletedLogger : MonoBehaviour
    {
        [SerializeField]
        private ExplorationLogger explorationLogger;

        public void LogCompleted(bool completed)
        {
            XElement completedElement = new XElement("Completed", completed);
            explorationLogger.AddLog(completedElement);
        }
    }

}
