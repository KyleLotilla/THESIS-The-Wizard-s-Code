using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DLSU.WizardCode.Spells.UI
{
    public class DisplayIconOfSpellInstanceToImage : MonoBehaviour
    {
        [SerializeField]
        private Image image;

        public void DisplayIcon(SpellInstance spellInstance)
        {
            if (spellInstance != null)
            {
                image.sprite = spellInstance.Icon;
            }
        }
    }

}
