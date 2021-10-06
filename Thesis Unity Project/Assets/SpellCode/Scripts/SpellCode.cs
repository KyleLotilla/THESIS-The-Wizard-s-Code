using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Spells;

namespace DLSU.WizardCode.SpellCodes
{
    [Serializable]
    public class SpellCode : IEnumerable<SpellInstance>
    {
        [SerializeField]
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        [SerializeField]
        private List<SpellInstance> spellInstances = new List<SpellInstance>();
        [SerializeField]
        private bool isEquipped;

        public bool IsEquipped
        {
            get
            {
                return isEquipped;
            }
            set
            {
                isEquipped = value;
            }
        }

        public int SpellInstanceCount
        {
            get
            {
                return spellInstances.Count;
            }
        }

        public SpellInstance this[int i]
        {
            get
            {
                return spellInstances[i];
            }
        }

        public void AddSpellInstance(SpellInstance spellInstance)
        {
            spellInstances.Add(spellInstance);
        }
        public void RemoveSpellInstance(SpellInstance spellInstance)
        {
            spellInstances.RemoveAll(x => x == spellInstance);
        }

        public void ClearSpells()
        {
            spellInstances.Clear();
        }

        public IEnumerator<SpellInstance> GetEnumerator()
        {
            return ((IEnumerable<SpellInstance>)spellInstances).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)spellInstances).GetEnumerator();
        }
    }

}
