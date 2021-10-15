using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DLSU.WizardCode.Levels.UI
{
    public class DisplayLevelOverviewToImageListItemView : MonoBehaviour
    {
        [SerializeField]
        private Image image;
        
        public void OnItemViewWithDataCreated(object data)
        {
            Level level = data as Level;
            if (level != null)
            {
                image.sprite = level.LevelOverview;
            }
        }
    }

}
