using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.SpellCodes
{
    [CreateAssetMenu(menuName = "Inventory/SpellCode Inventory")]
    public class SpellCodeInventory : ScriptableObject
    {
        [SerializeField]
        private List<SpellCode> unequippedSpellCodes;
        public IEnumerable<SpellCode> UnequippedSpellCodes
        {
            get
            {
                return unequippedSpellCodes;
            }
        }

        [SerializeField]
        private List<SpellCode> equippedSpellCodes;
        public IEnumerable<SpellCode> EquippedSpellCodes
        {
            get
            {
                return equippedSpellCodes;
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

        public IEnumerable<SpellCode> fullInventory
        {
            get
            {
                List<SpellCode> fullInventory = new List<SpellCode>(unequippedSpellCodes.Count + equippedSpellCodes.Count);
                fullInventory.AddRange(equippedSpellCodes);
                fullInventory.AddRange(unequippedSpellCodes);
                return fullInventory;
            }
        }

        void OnEnable()
        {
            if (unequippedSpellCodes != null)
            {
                unequippedSpellCodes.Clear();
            }
            else
            {
                unequippedSpellCodes = new List<SpellCode>();
            }

            if (EquippedSpellCodes != null)
            {
                equippedSpellCodes.Clear();
            }
            else
            {
                equippedSpellCodes = new List<SpellCode>(maxEquipped);
            }
        }

        public void AddSpellCode(SpellCode spellCode)
        {
            Debug.Assert(!spellCode.IsEquipped, name + ": Adding Spell that is Equipped");
            if (!spellCode.IsEquipped)
            {
                unequippedSpellCodes.Add(spellCode);
            }
        }

        public void EquipSpellCode(SpellCode spellCode)
        {
            if (equippedSpellCodes.Count + 1 < MaxEquipped)
            {
                Debug.Assert(!spellCode.IsEquipped, name + ": Equipping Spell that is already equipped");
                if (!spellCode.IsEquipped)
                {
                    equippedSpellCodes.Add(spellCode);
                    spellCode.IsEquipped = true;
                }
            }
        }

        public void UnequipSpellCode(SpellCode spellCode)
        {
            Debug.Assert(spellCode.IsEquipped, name + ": Unequipping Spell that is not equipped");
            if (spellCode.IsEquipped)
            {
                equippedSpellCodes.Remove(spellCode);
                spellCode.IsEquipped = false;
            }
        }

        public void RemoveSpellCode(SpellCode spellCode)
        {
            Debug.Assert(!spellCode.IsEquipped, name + ": Removing Spell that is Equipped");
            if (!spellCode.IsEquipped)
            {
                unequippedSpellCodes.Remove(spellCode);
            }
        }
    }

}
