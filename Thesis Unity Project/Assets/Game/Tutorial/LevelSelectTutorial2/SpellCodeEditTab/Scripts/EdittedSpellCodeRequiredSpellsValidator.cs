using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.SpellCodes.UI.Edit;
using DLSU.WizardCode.UI.Views;
using DLSU.WizardCode.UI.Slots;
using DLSU.WizardCode.Spells;

namespace DLSU.WizardCode.Tutorial.LevelSelectTutorial2.SpellCodeEditTab
{
    public class EdittedSpellCodeRequiredSpellsValidator : EdittedSpellCodeStateValidator
    {
        [SerializeField]
        private ListView listViewOfSpellInstances;
        [SerializeField]
        private List<Spell> requiredSpells;

        protected override bool Validate()
        {
            List<Spell> missingRequiredSpells = new List<Spell>(requiredSpells);
            IEnumerator<GameObject> itemViewsEnumerator = listViewOfSpellInstances.ItemViews.GetEnumerator();
            while (itemViewsEnumerator.MoveNext() && missingRequiredSpells.Count > 0)
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
                                missingRequiredSpells.Remove(spellInstanceHoldeOfSlot.SpellInstance.Spell);
                            }
                        }
                    }
                }
            }
            return missingRequiredSpells.Count <= 0;
        }
    }

}
