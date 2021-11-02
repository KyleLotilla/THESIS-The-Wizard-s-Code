using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;
using System.Xml;
using DLSU.WizardCode.SpellCodes;
using DLSU.WizardCode.Spells;

namespace DLSU.WizardCode.Logging.Exploration
{
    public class EquippedSpellCodesExplorationLogger : MonoBehaviour
    {
        [SerializeField]
        private SpellCodeInventory spellCodeInventory;
        [SerializeField]
        private ExplorationLogger explorationLogger;

        public void LogEquippedSpells()
        {
            if (spellCodeInventory.EquippedSpellCodesCount > 0)
            {
                XElement equippedSpellCodesElement = new XElement("EquippedSpellCodes");
                int currentSpellCodeEquippedID = 0;
                foreach (SpellCode spellCode in spellCodeInventory.EquippedSpellCodes)
                {
                    XElement spellCodeElement = new XElement("SpellCode");
                    spellCodeElement.Add(new XElement("ID", currentSpellCodeEquippedID));
                    spellCodeElement.Add(new XElement("Name", spellCode.Name));
                    XElement spellsElement = new XElement("Spells");
                    foreach (SpellInstance spellInstance in spellCode)
                    {
                        XElement spellElement = new XElement("Spell", spellInstance.Spell.SpellName);
                        spellsElement.Add(spellElement);
                    }
                    spellCodeElement.Add(spellsElement);
                    equippedSpellCodesElement.Add(spellCodeElement);
                    currentSpellCodeEquippedID++;
                }
                explorationLogger.AddLog(equippedSpellCodesElement);
            }
        }
    }

}
