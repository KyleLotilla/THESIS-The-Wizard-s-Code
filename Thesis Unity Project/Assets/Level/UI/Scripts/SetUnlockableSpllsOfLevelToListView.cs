using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.UI.Views;

namespace DLSU.WizardCode.Levels.UI
{
    public class SetUnlockableSpllsOfLevelToListView : MonoBehaviour
    {
        [SerializeField]
        private ListView listView;

        public void SetUnlockableSpells(Level level)
        {
            List<object> unlockableSpells = level.UnlockableSpells.Select(x => (object)x).ToList();
            listView.CreateList(unlockableSpells);
        }
    }
}


