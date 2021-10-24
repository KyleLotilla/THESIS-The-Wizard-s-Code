using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.Obstacles
{
    [CreateAssetMenu(menuName = "Obstacle/Obstacle")]
    public class Obstacle : ScriptableObject
    {
        [SerializeField]
        private int obstacleID;
        public int ObstacleID
        {
            get
            {
                return obstacleID;
            }
            set
            {
                obstacleID = value;
            }
        }
        [SerializeField]
        private string obstacleName;
        public string ObstacleName
        {
            get
            {
                return obstacleName;
            }
            set
            {
                obstacleName = value;
            }
        }
        [SerializeField]
        private Sprite icon;
        public Sprite Icon
        {
            get
            {
                return icon;
            }
            set
            {
                icon = value;
            }
        }
    }

}
