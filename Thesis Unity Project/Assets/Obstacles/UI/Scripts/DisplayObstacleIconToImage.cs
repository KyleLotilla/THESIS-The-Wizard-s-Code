using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DLSU.WizardCode.Obstacles.UI
{
    public class DisplayObstacleIconToImage : MonoBehaviour
    {
        [SerializeField]
        private Image image;

        public void DisplayObstacleIcon(Obstacle obstacle)
        {
            if (obstacle != null)
            {
                image.sprite = obstacle.Icon;
            }
        }
    }
}

