using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.UI.Views;

namespace DLSU.WizardCode.SpellCodes.UI.Inventory
{
    public class SetSpellCodeIconsToEquippedSpellCodeListView : MonoBehaviour
    {
        [SerializeField]
        private SpellCodeIcons spellCodeIcons;
        private int currentSpellCodeIconIndex = 0;

        public void OnItemViewWithDataCreated(GameObject itemView, object data)
        {
            IconView iconViewOfItemView = itemView.GetComponent<IconView>();
            if (iconViewOfItemView != null)
            {
                iconViewOfItemView.Icon.sprite = spellCodeIcons.GetIcon(currentSpellCodeIconIndex);
                currentSpellCodeIconIndex++;
            }
        }

        public void OnListViewClear()
        {
            currentSpellCodeIconIndex = 0;
        }
    }
}
