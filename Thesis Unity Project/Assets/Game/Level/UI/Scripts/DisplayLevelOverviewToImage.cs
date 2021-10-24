using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DLSU.WizardCode.Levels.UI
{
    public class DisplayLevelOverviewToImage : MonoBehaviour
    {
        [SerializeField]
        private Image image;
        
        public void DisplayLevelOverview(Level level)
        {
            if (level != null)
            {
                image.sprite = level.LevelOverview;
            }
        }
    }

}
