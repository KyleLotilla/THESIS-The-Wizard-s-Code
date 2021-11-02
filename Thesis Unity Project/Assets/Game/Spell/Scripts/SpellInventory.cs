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

        public int EquippedSpellInstancesCount
        {
            get
            {
                return equippedSpellInstances.Count;
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
            hideFlags = HideFlags.DontUnloadUnusedAsset;
        }

        public void AddUnequippedSpellInstance(SpellInstance spellInstance)
        {
            Debug.Assert(!spellInstance.IsEquipped, name + ": Adding Spell that is Equipped");
            if (!spellInstance.IsEquipped)
            {
                unequippedSpellInstances.Add(spellInstance);
            }
        }

        public void RemoveUnequippedSpellInstance(SpellInstance spellInstance)
        {
            Debug.Assert(!spellInstance.IsEquipped, name + ": Removing Spell that is Equipped when removing a unequipped spell");
            if (!spellInstance.IsEquipped)
            {
                unequippedSpellInstances.Remove(spellInstance);
            }
        }

        public void EquipSpellInstance(SpellInstance spellInstance)
        {
            if (equippedSpellInstances.Count + 1 < MaxEquipped)
            {
                Debug.Assert(!spellInstance.IsEquipped, name + ": Equipping Spell that is already equipped");
                if (!spellInstance.IsEquipped)
                {
                    RemoveUnequippedSpellInstance(spellInstance);
                    equippedSpellInstances.Add(spellInstance);
                    spellInstance.IsEquipped = true;
                }
            }
        }

        public void UnequipSpellInstance(SpellInstance spellInstance)
        {
            Debug.Assert(spellInstance.IsEquipped, name + ": Unequipping Spell that is not equipped");
            if (spellInstance.IsEquipped)
            {
                equippedSpellInstances.Remove(spellInstance);
                spellInstance.IsEquipped = false;
                AddUnequippedSpellInstance(spellInstance);
            }
        }

        public SpellInstance GetEquippedSpellInstanceByID(int spellID)
        {
            return equippedSpellInstances.Find(x => x.Spell.SpellID == spellID);
        }

        public SpellInstance GetUnequippedSpellInstanceByID(int spellID)
        {
            return unequippedSpellInstances.Find(x => x.Spell.SpellID == spellID);
        }
    }

}
