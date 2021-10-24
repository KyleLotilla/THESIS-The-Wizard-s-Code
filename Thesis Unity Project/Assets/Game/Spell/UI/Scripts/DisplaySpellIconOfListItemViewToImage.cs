using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DLSU.WizardCode.UI.Views;

namespace DLSU.WizardCode.Spells.UI
{
    public class DisplaySpellIconOfListItemViewToImage : MonoBehaviour
    {
        [SerializeField]
        private SpellDatabase spellDatabase;
        [SerializeField]
        private Image image;
        public void OnItemViewWithDataCreated(object data)
        {
            Spell spell = data as Spell;
            if (spell != null)
            {
                SpellInstance tempSpellInstance = spellDatabase.GetSpellInstance(spell);
                image.sprite = tempSpellInstance.Icon;
            }
        }
    }
}

