using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DLSU.WizardCode.Events;

namespace DLSU.WizardCode.Obstacles
{
    public class ObstacleHolder : MonoBehaviour
    {
        [SerializeField]
        private Obstacle obstacle;
        public Obstacle Obstacle
        {
            get
            {
                return obstacle;
            }
            set
            {
                obstacle = value;
                if (obstacle != null)
                {
                    onObstacleChanged?.Invoke(obstacle);
                }
                else
                {
                    onNoObstacleSet?.Invoke();
                }
            }
        }
        [SerializeField]
        private UnityEventOneObstacleParam onObstacleChanged;
        [SerializeField]
        private UnityEvent onNoObstacleSet;


    }
}

