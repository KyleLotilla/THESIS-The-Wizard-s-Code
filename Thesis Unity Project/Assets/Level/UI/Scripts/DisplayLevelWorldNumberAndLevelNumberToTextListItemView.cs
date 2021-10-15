using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DLSU.WizardCode.Levels.UI
{
    public class DisplayLevelWorldNumberAndLevelNumberToTextListItemView : MonoBehaviour
    {
        [SerializeField]
        private Text text;

        public void OnItemViewWithDataCreated(object data)
        {
            Level level = data as Level;
            if (level != null)
            {
                text.text = level.WorldNumber.ToString() + "-" + level.LevelNumber.ToString();
            }
        }
    }
}


