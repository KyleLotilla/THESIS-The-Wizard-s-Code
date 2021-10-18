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
        private List<Spell> spells;

        public void AddSpellsList()
        {
            List<SpellInstance> spellInstances = spellDatabase.GetSpellInstances(spells);
            possibleSpellInstancesToAddToSpellCodeList.Value.AddRange(spellInstances);
        }
    }

}
