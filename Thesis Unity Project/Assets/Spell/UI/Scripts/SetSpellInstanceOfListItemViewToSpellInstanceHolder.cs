using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.Spells.UI
{
    public class SetSpellInstanceOfListItemViewToSpellInstanceHolder : MonoBehaviour
    {
        [SerializeField]
        private SpellInstanceHolder spellInstanceHolder;

        public void OnItemViewWithDataCreated(object data)
        {
            SpellInstance spellInstance = data as SpellInstance;
            if (spellInstance != null)
            {
                spellInstanceHolder.SpellInstance = spellInstance;
            }
        }
    }

}

