using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Events;
using DLSU.WizardCode.ScriptableObjectVariables;
using DLSU.WizardCode.Spells;

namespace DLSU.WizardCode.Levels
{
    public class UnlockSpellsForCurrentLevel : MonoBehaviour
    {
        [SerializeField]
        private LevelVariable currentLevel;
        [SerializeField]
        private SpellDatabase spellDatabase;
        [SerializeField]
        private SpellInventory spellInventory;
        [SerializeField]
        private UnityEventOneSpellInstanceListParam onUnlockedSpells;

        public void UnlockSpells()
        {
            List<SpellInstance> unlockedSpellInstances = new List<SpellInstance>();
            foreach (Spell spell in currentLevel.Value.UnlockableSpells)
            {
                SpellInstance spellInstance = spellDatabase.GetSpellInstance(spell);
                spellInventory.AddSpellInstance(spellInstance);
                unlockedSpellInstances.Add(spellInstance);
            }
            onUnlockedSpells?.Invoke(unlockedSpellInstances);
        }
    }
}
