using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.UI.Views;
using DLSU.WizardCode.ScriptableObjectVariables;
using DLSU.WizardCode.Spells;

namespace DLSU.WizardCode.Levels
{
    public class DisplayUnlockableSpellsInCurrentLevelInListView : MonoBehaviour
    {
        [SerializeField]
        private LevelVariable currentLevel;
        [SerializeField]
        private ListView listView;

        public void DisplaySpells()
        {
            List<object> unlockableSpells = currentLevel.Value.UnlockableSpells.Select(x => (object)x).ToList();
            listView.CreateList(unlockableSpells);
        }
    }
}
