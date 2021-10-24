using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.ScriptableObjectVariables;
using DLSU.WizardCode.UI.Views;
using DLSU.WizardCode.UI.Slots;
using DLSU.WizardCode.Spells;

namespace DLSU.WizardCode.SpellCodes.UI.Edit
{
    public class SaveSpellInstancesOfCurrentEditingSpellCodeFromListView : MonoBehaviour
    {
        [SerializeField]
        private SpellCodeVariable currentEditingSpellCode;
        [SerializeField]
        private ListView listView;

        public void SaveSpellInstancesOfCurrentEditingSpellCode()
        {
            currentEditingSpellCode.Value.ClearSpells();
            foreach (GameObject itemView in listView.ItemViews)
            {
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
                                currentEditingSpellCode.Value.AddSpellInstance(spellInstanceHoldeOfSlot.SpellInstance);
                            }
                        }
                    }
                }
            }
        }
    }

}
