using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DLSU.WizardCode.Logging.UI
{
    public class SetUploadPercentToSlider : MonoBehaviour
    {
        [SerializeField]
        private Slider slider;

        public void onUploadProgressed(float uploadPercent)
        {
            slider.value = uploadPercent;
        }
    }

}
