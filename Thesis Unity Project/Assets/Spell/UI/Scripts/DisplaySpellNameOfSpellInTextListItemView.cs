using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DLSU.WizardCode.UI.Views;

namespace DLSU.WizardCode.Spells.UI
{
    public class DisplaySpellNameOfSpellInTextListItemView : MonoBehaviour
    {
        [SerializeField]
        private Text text;
        public void OnItemViewWithDataCreated(object data)
        {
            Spell spell = data as Spell;
            if (spell != null)
            {
                text.text = spell.SpellName;
            }
        }
    }

}
