using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.ScriptableObjectVariables;
using System.Xml.Linq;

namespace DLSU.WizardCode.Logging.Exploration
{
    public class MovesUsedExplorationLogger : MonoBehaviour
    {
        [SerializeField]
        private IntVariable explorationMovesUsed;
        [SerializeField]
        private ExplorationLogger explorationLogger;

        public void LogMovesUsed()
        {
            XElement movesUsedElement = new XElement("MovesUsed", explorationMovesUsed.Value);
            explorationLogger.AddLog(movesUsedElement);
        }
    }

}
