using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DLSU.WizardCode.Levels.UI.LevelInformation
{
    public class DisplayLevelOverallStarsNeededToUnlockToText : MonoBehaviour
    {
        [SerializeField]
        private Text text;
        public void DisplayOverallStarsNeededToUnlock(Level level)
        {
            text.text = level.OverallStarsNeededToUnlock.ToString();
        }
    }
}

