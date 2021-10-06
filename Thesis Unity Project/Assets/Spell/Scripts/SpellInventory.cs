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
            Debug.Assert(!spell.IsEquipped, name + ": Adding Spell that is Equipped");
            if (!spell.IsEquipped)
            {
                unequippedSpells.Add(spell);
            }
        }

        public void EquipSpell(SpellInstance spell)
        {
            if (equippedSpells.Count + 1 < MaxEquipped)
            {
                Debug.Assert(!spell.IsEquipped, name + ": Equipping Spell that is already equipped");
                if (!spell.IsEquipped)
                {
                    equippedSpells.Add(spell);
                    spell.IsEquipped = true;
                }
            }
        }

        public void UnequipSpell(SpellInstance spell)
        {
            Debug.Assert(spell.IsEquipped, name + ": Unequipping Spell that is not equipped");
            if (spell.IsEquipped)
            {
                equippedSpells.Remove(spell);
                spell.IsEquipped = false;
            }
        }

        public void RemoveSpell(SpellInstance spell)
        {
            Debug.Assert(!spell.IsEquipped, name + ": Removing Spell that is Equipped");
            if (!spell.IsEquipped)
            {
                unequippedSpells.Remove(spell);
            }
        }
    }

}
