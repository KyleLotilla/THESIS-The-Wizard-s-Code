using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DLSU.WizardCode.SpellCodes.UI.Edit
{
    public class EdittedSpellCodeNameLengthValidator : EdittedSpellCodeStateValidator
    {
        [SerializeField]
        private InputField spellCodeNameInputField; 

        protected override bool Validate()
        {
            return spellCodeNameInputField.text.Length > 0;
        }
    }

}
