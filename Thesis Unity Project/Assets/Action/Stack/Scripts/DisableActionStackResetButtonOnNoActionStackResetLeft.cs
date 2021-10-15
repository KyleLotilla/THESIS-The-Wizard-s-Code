using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DLSU.WizardCode.ScriptableObjectVariables;

namespace DLSU.WizardCode.Actions.Stack
{
    public class DisableActionStackResetButtonOnNoActionStackResetLeft : MonoBehaviour
    {
        [SerializeField]
        private IntVariable actionStackResetCount;
        [SerializeField]
        private Button resetButton;

        public void OnActionStackReset()
        {
            if (actionStackResetCount.Value <= 0)
            {
                resetButton.interactable = false;
            }
        }
    }

}

