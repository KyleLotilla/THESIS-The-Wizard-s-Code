using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Spells;
using System.Xml.Linq;

namespace DLSU.WizardCode.Logging.Exploration
{
    public class EquippedSpellInstancesExplorationLogger : MonoBehaviour
    {
        [SerializeField]
        private SpellInventory spellInventory;
        [SerializeField]
        private ExplorationLogger explorationLogger;

        public void LogEquippedSpells()
        {
            if (spellInventory.EquippedSpellInstancesCount > 0)
            {
                XElement equippedSpellsElement = new XElement("EquippedSpells");
                foreach (SpellInstance spellInstance in spellInventory.EquippedSpellInstances)
                {
                    XElement spellElement = new XElement("Spell", spellInstance.Spell.SpellName);
                    equippedSpellsElement.Add(spellElement);
                }
                explorationLogger.AddLog(equippedSpellsElement);
            }
        }
    }

}
