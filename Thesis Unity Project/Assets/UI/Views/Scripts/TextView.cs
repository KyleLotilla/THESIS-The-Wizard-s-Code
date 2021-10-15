using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DLSU.WizardCode.UI.Views
{
    public class TextView : MonoBehaviour
    {
        [SerializeField]
        private Text text;
        public Text Text
        {
            get
            {
                return text;
            }
        }
    }
}

