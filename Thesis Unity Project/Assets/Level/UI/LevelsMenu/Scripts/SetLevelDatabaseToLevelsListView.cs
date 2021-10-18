using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.UI.Views;

namespace DLSU.WizardCode.Levels.UI.LevelsMenu
{
    public class SetLevelDatabaseToLevelsListView : MonoBehaviour
    {
        [SerializeField]
        private LevelDatabase levelDatabase;
        [SerializeField]
        private ListView levelsListView;

        public void SetListView()
        {
            List<object> levelsOfLevelDatabase = levelDatabase.Select(x => (object)x).ToList();
            levelsListView.CreateList(levelsOfLevelDatabase);
        }
    }

}
