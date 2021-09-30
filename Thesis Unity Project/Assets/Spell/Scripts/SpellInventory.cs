using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.Spells
{
    [CreateAssetMenu(menuName = "Inventory/Spell Inventory")]
    public class SpellInventory : ScriptableObject
    {
        [SerializeField]
        private List<SpellInstance> unequippedSpells;
        public IEnumerable<SpellInstance> UnequippedSpells
        {
            get
            {
                return unequippedSpells;
            }
        }

        [SerializeField]
        private List<SpellInstance> equippedSpells;
        public IEnumerable<SpellInstance> EquippedSpells
        {
            get
            {
                return equippedSpells;
            }
        }

        [SerializeField]
        private int maxEquipped;
        public int MaxEquipped
        {
            get
            {
                return maxEquipped;
            }
            set

            {
                maxEquipped = value;
            }
        }

        public IEnumerable<SpellInstance> fullInventory
        {
            get
            {
                List<SpellInstance> fullInventory = new List<SpellInstance>(unequippedSpells.Count + equippedSpells.Count);
                fullInventory.AddRange(equippedSpells);
                fullInventory.AddRange(unequippedSpells);
                return fullInventory;
            }
        }

        void OnEnable()
        {
            if (unequippedSpells != null)
            {
                unequippedSpells.Clear();
            }
            else
            {
                unequippedSpells = new List<SpellInstance>();
            }

            if (EquippedSpells != null)
            {
                equippedSpells.Clear();
            }
            else
            {
                equippedSpells = new List<SpellInstance>(MaxEquipped);
            }
        }

        public void AddSpell(SpellInstance spell)
        {
            Debug.Assert(!spell.isEquipped, name + ": Adding Spell that is Equipped");
            if (!spell.isEquipped)
            {
                unequippedSpells.Add(spell);
            }
        }

        public void EquipSpell(SpellInstance spell)
        {
            if (equippedSpells.Count + 1 < MaxEquipped)
            {
                Debug.Assert(!spell.isEquipped, name + ": Equipping Spell that is already equipped");
                if (!spell.isEquipped)
                {
                    equippedSpells.Add(spell);
                    spell.isEquipped = true;
                }
            }
        }

        public void UnequipSpell(SpellInstance spell)
        {
            Debug.Assert(spell.isEquipped, name + ": Unequipping Spell that is not equipped");
            if (spell.isEquipped)
            {
                equippedSpells.Remove(spell);
                spell.isEquipped = false;
            }
        }

        public void RemoveSpell(SpellInstance spell)
        {
            Debug.Assert(!spell.isEquipped, name + ": Removing Spell that is Equipped");
            if (!spell.isEquipped)
            {
                unequippedSpells.Remove(spell);
            }
        }
    }

}
