using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DLSU.WizardCode.ScriptableObjectVariables;

namespace DLSU.WizardCode.UI
{
    public class SetIntVariableToText : MonoBehaviour
    {
        [SerializeField]
        private IntVariable intVariable;
        [SerializeField]
        private Text text;
        [SerializeField]
        private bool setOnStart = true;

        void Start()
        {
            if (setOnStart)
            {
                SetText();
            }
        }

        public void SetText()
        {
            text.text = intVariable.Value.ToString();
        }
    }

}
