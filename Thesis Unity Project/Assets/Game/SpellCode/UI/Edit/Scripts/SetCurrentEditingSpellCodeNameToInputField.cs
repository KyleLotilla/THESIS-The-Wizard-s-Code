using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DLSU.WizardCode.ScriptableObjectVariables;

namespace DLSU.WizardCode.SpellCodes.UI.Edit
{
    public class SetCurrentEditingSpellCodeNameToInputField : MonoBehaviour
    {
        [SerializeField]
        private SpellCodeVariable currentEditingSpellCode;
        [SerializeField]
        private InputField inputField;

        public void SetCurrrentEdittedSpellCodeName()
        {
            inputField.text = currentEditingSpellCode.Value.Name;
        }
    }

}
