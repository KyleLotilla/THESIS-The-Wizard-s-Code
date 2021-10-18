using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.UI.Views;

namespace DLSU.WizardCode.Levels.UI.LevelInformation
{
    public class SetObstacleCountsOfLevelToListView : MonoBehaviour
    {
        [SerializeField]
        private ListView listView;

        public void SetObstacleCounts(Level level)
        {
            List<object> obstacleCounts = level.ObstalceCounts.Select(x => (object)x).ToList();
            listView.CreateList(obstacleCounts);
        }
    }
}


