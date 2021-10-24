using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.SpellCodes.UI.Edit
{
    public class EdittedSpellCodeMultiStateValidator : EdittedSpellCodeStateValidator
    {
        [SerializeField]
        List<EdittedSpellCodeStateValidator> edittedSpellCodeStateValidators;

        protected override bool Validate()
        {
            bool isSpellCodeValid = true;
            foreach (EdittedSpellCodeStateValidator edittedSpellCodeStateValidator in edittedSpellCodeStateValidators)
            {
                bool isSpellCodeStateValid = edittedSpellCodeStateValidator.ValidateSpellCodeState();
                if (!isSpellCodeStateValid)
                {
                    isSpellCodeValid = false;
                }
            }
            return isSpellCodeValid;
        }

        public void ValidateAllStates()
        {
            ValidateSpellCodeState();
        }
    }

}
