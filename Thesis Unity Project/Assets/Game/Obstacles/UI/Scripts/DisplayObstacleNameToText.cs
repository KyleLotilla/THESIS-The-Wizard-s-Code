using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DLSU.WizardCode.Obstacles.UI
{
    public class DisplayObstacleNameToText : MonoBehaviour
    {
        [SerializeField]
        private Text text;

        public void DisplayObstacleName(Obstacle obstacle)
        {
            if (obstacle != null)
            {
                text.text = obstacle.ObstacleName;
            }
        }
    }
}

