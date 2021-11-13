using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DLSU.WizardCode.Logging.UI
{
    public class SetUploadPercentToText : MonoBehaviour
    {
        [SerializeField]
        private Text text;

        public void OnUploadProgressed(float uploadPercent)
        {
            text.text = (uploadPercent * 100).ToString() + "%";
        }
    }

}
