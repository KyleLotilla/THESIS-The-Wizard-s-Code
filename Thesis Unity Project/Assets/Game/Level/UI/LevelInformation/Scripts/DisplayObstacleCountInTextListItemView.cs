using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DLSU.WizardCode.Obstacles.UI.LevelInformation
{
    public class DisplayObstacleCountInTextListItemView : MonoBehaviour
    {
        [SerializeField]
        private Text text;

        public void OnItemViewWithDataCreated(object data)
        {
            KeyValuePair<Obstacle, int> obstacleCount = (KeyValuePair<Obstacle, int>)data;
            text.text = obstacleCount.Value.ToString();
        }
    }
}
