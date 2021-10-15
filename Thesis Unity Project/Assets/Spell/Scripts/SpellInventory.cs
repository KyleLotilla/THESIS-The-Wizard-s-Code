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
        private List<SpellInstance> unequippedSpellInstances;
        public IEnumerable<SpellInstance> UnequippedSpellInstances
        {
            get
            {
                return unequippedSpellInstances;
            }
        }
        [SerializeField]
        private List<SpellInstance> equippedSpellInstances;
        public IEnumerable<SpellInstance> EquippedSpellInstances
        {
            get
            {
                return equippedSpellInstances;
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
                List<SpellInstance> fullInventory = new List<SpellInstance>(unequippedSpellInstances.Count + equippedSpellInstances.Count);
                fullInventory.AddRange(equippedSpellInstances);
                fullInventory.AddRange(unequippedSpellInstances);
                return fullInventory;
            }
        }

        void OnEnable()
        {
            if (unequippedSpellInstances != null)
            {
                unequippedSpellInstances.Clear();
            }
            else
            {
                unequippedSpellInstances = new List<SpellInstance>();
            }

            if (EquippedSpellInstances != null)
            {
                equippedSpellInstances.Clear();
            }
            else
            {
                equippedSpellInstances = new List<SpellInstance>(MaxEquipped);
            }
        }

        public void AddSpellInstance(SpellInstance spell)
        {
            Debug.Assert(!spell.IsEquipped, name + ": Adding Spell that is Equipped");
            if (!spell.IsEquipped)
            {
                unequippedSpellInstances.Add(spell);
            }
        }

        public void EquipSpellInstance(SpellInstance spell)
        {
            if (equippedSpellInstances.Count + 1 < MaxEquipped)
            {
                Debug.Assert(!spell.IsEquipped, name + ": Equipping Spell that is already equipped");
                if (!spell.IsEquipped)
                {
                    equippedSpellInstances.Add(spell);
                    spell.IsEquipped = true;
                }
            }
        }

        public void UnequipSpellInstance(SpellInstance spell)
        {
            Debug.Assert(spell.IsEquipped, name + ": Unequipping Spell that is not equipped");
            if (spell.IsEquipped)
            {
                equippedSpellInstances.Remove(spell);
                spell.IsEquipped = false;
            }
        }

        public void RemoveSpellInstance(SpellInstance spell)
        {
            Debug.Assert(!spell.IsEquipped, name + ": Removing Spell that is Equipped");
            if (!spell.IsEquipped)
            {
                unequippedSpellInstances.Remove(spell);
            }
        }
    }

}
