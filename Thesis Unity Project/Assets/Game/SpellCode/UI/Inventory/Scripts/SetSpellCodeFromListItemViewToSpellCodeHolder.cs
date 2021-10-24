using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.SpellCodes.UI.Inventory
{
    public class SetSpellCodeFromListItemViewToSpellCodeHolder : MonoBehaviour
    {
        [SerializeField]
        private SpellCodeHolder spellCodeHolder;

        public void OnItemViewWithDataCreated(object data)
        {
            SpellCode spellCode = data as SpellCode;
            if (spellCode != null)
            {
                spellCodeHolder.SpellCode = spellCode;
            }
        }
    }
}
