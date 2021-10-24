using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.UI.Views;
using DLSU.WizardCode.UI.Slots;
using DLSU.WizardCode.ScriptableObjectVariables;
using DLSU.WizardCode.Spells;

namespace DLSU.WizardCode.SpellCodes.UI.Edit
{
    public class EdittedSpellCodeMinimumSpellsValidator : EdittedSpellCodeStateValidator
    {
        [SerializeField]
        private ListView listViewOfSpellInstances;
        [SerializeField]
        private IntVariable minimumSpellCodeSpells;

        protected override bool Validate()
        {
            bool hasMinimumAmountOfSpells = false;
            int amountOfSpells = 0;
            IEnumerator<GameObject> itemViewsEnumerator = listViewOfSpellInstances.ItemViews.GetEnumerator();
            while (itemViewsEnumerator.MoveNext() && !hasMinimumAmountOfSpells)
            {
                GameObject itemView = itemViewsEnumerator.Current;
                SlotSpace slotSpaceOfItemView = itemView.GetComponent<SlotSpace>();
                if (slotSpaceOfItemView != null)
                {
                    if (!slotSpaceOfItemView.IsEmpty)
                    {
                        SpellInstanceHolder spellInstanceHoldeOfSlot = slotSpaceOfItemView.Slot.GetComponent<SpellInstanceHolder>();
                        if (spellInstanceHoldeOfSlot != null)
                        {
                            if (spellInstanceHoldeOfSlot.SpellInstance != null)
                            {
                                amountOfSpells++;
                                if (amountOfSpells >= minimumSpellCodeSpells.Value)
                                {
                                    hasMinimumAmountOfSpells = true;
                                }
                            }
                        }
                    }
                }
            }
            return hasMinimumAmountOfSpells;
        }
    }

}
