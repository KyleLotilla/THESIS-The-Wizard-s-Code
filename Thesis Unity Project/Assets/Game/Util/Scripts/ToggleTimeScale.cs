using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.Util
{
    public class ToggleTimeScale : MonoBehaviour
    {
        public void Toggle(bool isTimeScaleActive)
        {
            float timeScale = 1.0f;
            if (!isTimeScaleActive)
            {
                timeScale = 0.0f;
            }
            Time.timeScale = timeScale;
        }
    }

}

