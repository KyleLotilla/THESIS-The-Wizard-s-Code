using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Obstacles;

namespace DLSU.WizardCode.Levels.UI.LevelInformation
{
    public class SetObstacleFromObstacleCountsListItemViewToObstacleHolder : MonoBehaviour
    {
        [SerializeField]
        private ObstacleHolder obstalceHolder;

        public void OnItemViewWithDataCreated(object data)
        {
            KeyValuePair<Obstacle, int> obstacleCount = (KeyValuePair<Obstacle, int>) data;
            obstalceHolder.Obstacle = obstacleCount.Key;
        }
    }
}

