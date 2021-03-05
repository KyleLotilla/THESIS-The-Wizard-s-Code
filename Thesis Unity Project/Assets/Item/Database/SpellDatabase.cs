using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Linq;
using System.Xml.Linq;
using System.IO;

[CreateAssetMenu(menuName = "Database/Spell Database")]
public class SpellDatabase : XMLDatabase
{
    [SerializeField]
    private Dictionary<int, Spell> spells;
    [SerializeField]
    private string pathToXMLDatabase;

    void OnEnable()
    {
        if (spells != null)
        {
            spells.Clear();
        }
        else
        {
            spells = new Dictionary<int, Spell>();
        }

        LoadXml(LoadLocalXmlDocument(pathToXMLDatabase));
    }

    void LoadXml(XDocument document)
    {
        XElement root = document.Root;
        foreach (XElement element in root.Elements())
        {
            if (element.Elements("ID").Any())
            {
                Spell spell = new Spell();
                spell.spellID = int.Parse(element.Element("ID").Value);

                if (element.Elements("Name").Any())
                {
                    spell.name = element.Element("Name").Value;
                }

                if (element.Elements("Description").Any())
                {
                    spell.description = element.Element("Description").Value;
                }

                if (element.Elements("Icon").Any())
                {
                    spell.pathToIcon = element.Element("Icon").Value;
                    spell.icon = Resources.Load<Sprite>(spell.pathToIcon);
                }

                if (element.Elements("ActionSlot").Any())
                {
                    spell.pathToActionSlot = element.Element("ActionSlot").Value;
                }

                spells.Add(spell.spellID, spell);
            }
        }
    }

    public Spell GetSpell(int id)
    {
        if (spells.ContainsKey(id))
        {
            Spell spell = spells[id];
            Spell spellCopy = new Spell();
            spellCopy.spellID = spell.spellID;
            spellCopy.name = spell.name;
            spellCopy.description = spell.description;
            spellCopy.icon = spell.icon;
            spellCopy.pathToIcon = spell.pathToIcon;
            spellCopy.pathToActionSlot = spell.pathToActionSlot;
            return spellCopy;
        }
        else
        {
            return null;
        }
    }
}
