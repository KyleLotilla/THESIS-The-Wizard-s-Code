using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Events;
using UnityEngine.Events;

namespace DLSU.WizardCode.Levels
{
    public class LevelHolder : MonoBehaviour
    {
        [SerializeField]
        private Level level;
        public Level Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
                if (level != null)
                {
                    onLevelChanged?.Invoke(level);
                }
                else
                {
                    onNoLevelSet?.Invoke();
                }
            }
        }
        [SerializeField]
        private UnityEventOneLevelParam onLevelChanged;
        [SerializeField]
        private UnityEvent onNoLevelSet;
    }
}
