using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.ScriptableObjectVariables;

namespace DLSU.WizardCode.Logging.Exploration
{
    public class StarsObtainedExplorationLogger : MonoBehaviour
    {
        [SerializeField]
        private ExplorationLogger explorationLogger;

        public void LogCurrentScore(int starsObtained)
        {
            XElement starsObtainedElement = new XElement("StarsObtained", starsObtained);
            explorationLogger.AddLog(starsObtainedElement);
        }
    }

}
