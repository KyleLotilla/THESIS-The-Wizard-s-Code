using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DLSU.WizardCode.SpellCodes
{
    public class CheckIfMaxEquippedSpellCodesIsExceeded : MonoBehaviour
    {
        [SerializeField]
        private SpellCodeInventory spellCodeInventory;
        [SerializeField]
        private UnityEvent onMaxEquippedSpellCodesExceeded;
        [SerializeField]
        private UnityEvent onMaxEquippedSpellCodesNotExceeded;
        public void Check()
        {
            if (spellCodeInventory.IsMaxEquippedExceeded)
            {
                onMaxEquippedSpellCodesExceeded?.Invoke();
            }
            else
            {
                onMaxEquippedSpellCodesNotExceeded?.Invoke();
            }
        }
    }
}
