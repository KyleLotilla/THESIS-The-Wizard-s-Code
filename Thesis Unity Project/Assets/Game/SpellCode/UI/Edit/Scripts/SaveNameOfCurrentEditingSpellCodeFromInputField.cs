using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.ScriptableObjectVariables;
using UnityEngine.UI;

namespace DLSU.WizardCode.SpellCodes.UI.Edit
{
    public class SaveNameOfCurrentEditingSpellCodeFromInputField : MonoBehaviour
    {
        [SerializeField]
        private SpellCodeVariable currentEditingSpellCode;
        [SerializeField]
        private InputField inputField;

        public void SaveNameOfCurrentEditingSpellCode()
        {
            currentEditingSpellCode.Value.Name = inputField.text;
        }
    }
}
