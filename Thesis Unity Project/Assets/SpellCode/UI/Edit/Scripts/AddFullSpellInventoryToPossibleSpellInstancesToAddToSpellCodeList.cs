using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.ScriptableObjectVariables;
using DLSU.WizardCode.Spells;

namespace DLSU.WizardCode.SpellCodes.UI.Edit
{
    public class AddFullSpellInventoryToPossibleSpellInstancesToAddToSpellCodeList : MonoBehaviour
    {
        [SerializeField]
        private SpellInstanceListVariable possibleSpellInstancesToAddToSpellCodeList;
        [SerializeField]
        private SpellInventory spellInventory;

        public void AddFullInventory()
        {
            IEnumerable<SpellInstance> fullSpellInventory = spellInventory.fullInventory;
            possibleSpellInstancesToAddToSpellCodeList.Value.AddRange(fullSpellInventory);
        }
    }

}
