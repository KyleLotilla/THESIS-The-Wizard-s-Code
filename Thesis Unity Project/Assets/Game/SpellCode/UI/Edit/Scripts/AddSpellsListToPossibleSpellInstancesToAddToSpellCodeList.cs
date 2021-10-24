using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.ScriptableObjectVariables;
using DLSU.WizardCode.Spells;

namespace DLSU.WizardCode.SpellCodes.UI.Edit
{
    public class AddSpellsListToPossibleSpellInstancesToAddToSpellCodeList : MonoBehaviour
    {
        [SerializeField]
        private SpellInstanceListVariable possibleSpellInstancesToAddToSpellCodeList;
        [SerializeField]
        private SpellDatabase spellDatabase;
        [SerializeField]
        private SpellInventory spellInventory;
        [SerializeField]
        private List<Spell> spells;

        public void AddSpellsList()
        {
            List<SpellInstance> spellInstances = new List<SpellInstance>();
            foreach (Spell spell in spells)
            {
                SpellInstance spellInstance = spellInventory.GetEquippedSpellInstanceByID(spell.SpellID);
                if (spellInstance == null)
                {
                    spellInstance = spellInventory.GetUnequippedSpellInstanceByID(spell.SpellID);
                    if (spellInstance == null)
                    {
                        spellInstance = spellDatabase.GetSpellInstance(spell);
                    }
                }
                spellInstances.Add(spellInstance);
            }
            possibleSpellInstancesToAddToSpellCodeList.Value.AddRange(spellInstances);
        }
    }

}
