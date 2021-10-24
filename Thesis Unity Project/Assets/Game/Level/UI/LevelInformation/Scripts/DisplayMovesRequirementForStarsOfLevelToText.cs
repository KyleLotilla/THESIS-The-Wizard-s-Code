using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DLSU.WizardCode.Levels.UI.LevelInformation
{
    public class DisplayMovesRequirementForStarsOfLevelToText : MonoBehaviour
    {
        [SerializeField]
        private Text text; 
        [SerializeField]
        private int numberOfStars;

        public void DisplayMovesRequirements(Level level)
        {
            if (level != null)
            {
                text.text = level.GetMovesRequirement(numberOfStars).ToString();
            }
        }
    }

}

