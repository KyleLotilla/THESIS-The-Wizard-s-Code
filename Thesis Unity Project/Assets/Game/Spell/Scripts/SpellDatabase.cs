using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Save;

namespace DLSU.WizardCode.Spells
{
    [CreateAssetMenu(menuName = "Spell/Spell Database")]
    public class SpellDatabase : ScriptableObject
    {
        [SerializeField]
        private List<Spell> spells;
        [SerializeField]
        private PlayerProfile playerProfile;

        void OnEnable()
        {
        }

        public SpellInstance GetSpellInstance(int id)
        {
            Debug.Assert(id >= 0 && id < spells.Count, name + ": Spell ID not found");
            if (id >= 0 && id < spells.Count)
            {
                Spell spell = spells[id];
                return GetSpellInstance(spell);
            }
            else
            {
                return null;
            }
        }

        public SpellInstance GetSpellInstance(Spell spell)
        {
            Debug.Assert(spell.SpellID >= 0 && spell.SpellID < spells.Count, name + ": Spell not found in database");
            if (spell.SpellID >= 0 && spell.SpellID < spells.Count)
            {
                SpellInstance spellInstance = new SpellInstance();
                spellInstance.Spell = spell;
                if (playerProfile.Gender == Gender.MALE)
                {
                    spellInstance.Icon = spell.MaleIcon;
                }
                else
                {
                    spellInstance.Icon = spell.FemaleIcon;
                }
                return spellInstance;
            }
            else
            {
                return null;
            }
        }

        public List<SpellInstance> GetSpellInstances(List<Spell> spells)
        {
            List<SpellInstance> spellInstances = new List<SpellInstance>();
            foreach (Spell spell in spells)
            {
                spellInstances.Add(GetSpellInstance(spell));
            }
            return spellInstances;
        }
    }

}

