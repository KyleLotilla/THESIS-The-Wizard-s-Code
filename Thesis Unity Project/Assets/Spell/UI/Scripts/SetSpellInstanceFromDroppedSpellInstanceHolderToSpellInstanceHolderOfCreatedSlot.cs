using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

namespace DLSU.WizardCode.Spells.UI
{
    public class SetSpellInstanceFromDroppedSpellInstanceHolderToSpellInstanceHolderOfCreatedSlot : MonoBehaviour
    {
        public void onSlotPrefabCreatedFromDropped(GameObject dropped, GameObject createdSlot)
        {
            SpellInstanceHolder spellInstanceHolderOfDropped = dropped.GetComponent<SpellInstanceHolder>();
            SpellInstanceHolder spellInstanceHolderOFCreatedSlot = createdSlot.GetComponent<SpellInstanceHolder>();
            if (spellInstanceHolderOfDropped != null && spellInstanceHolderOFCreatedSlot != null)
            {
                spellInstanceHolderOFCreatedSlot.SpellInstance = spellInstanceHolderOfDropped.SpellInstance;
            }
        }
    }
}
