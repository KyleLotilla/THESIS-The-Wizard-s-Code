using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DLSU.WizardCode.Logging.Exploration
{
    public class InitializeExplorationLoggerOnStart : MonoBehaviour
    {
        [SerializeField]
        private ExplorationLogger explorationLogger;
        [SerializeField]
        private UnityEvent onExplorationLoggerInitialized;

        void Start()
        {
            explorationLogger.InitializeLogger();
            onExplorationLoggerInitialized?.Invoke();
        }

    }

}
