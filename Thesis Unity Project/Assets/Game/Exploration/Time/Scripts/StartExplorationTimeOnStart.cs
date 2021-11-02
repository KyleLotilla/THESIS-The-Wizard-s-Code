using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.Exploration.Time
{
    public class StartExplorationTimeOnStart : MonoBehaviour
    {
        [SerializeField]
        private ExplorationTime explorationTime;
        private void Start()
        {
            explorationTime.StartExplorationTime();
        }
    }

}
