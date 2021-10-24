using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.Levels.UI.LevelsMenu
{
    public class SetLevelFromListIemViewToLevelHolder : MonoBehaviour
    {
        [SerializeField]
        private LevelHolder levelHolder;
        public void OnItemViewWithDataCreated(object data)
        {
            Level level = data as Level;
            if (level != null)
            {
                levelHolder.Level = level;
            }
        }
    }

}
