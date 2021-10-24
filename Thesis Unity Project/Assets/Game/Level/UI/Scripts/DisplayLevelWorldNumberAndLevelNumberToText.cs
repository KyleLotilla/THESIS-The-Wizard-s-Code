using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DLSU.WizardCode.Levels.UI
{
    public class DisplayLevelWorldNumberAndLevelNumberToText : MonoBehaviour
    {
        [SerializeField]
        private Text text;

        public void DisplayLevelWorldAndLevelNumber(Level level)
        {
            if (level != null)
            {
                text.text = level.WorldNumber.ToString() + "-" + level.LevelNumber.ToString();
            }
        }
    }
}


