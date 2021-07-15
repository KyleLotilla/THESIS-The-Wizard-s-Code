using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Xml.Linq;
using System.IO;

[CreateAssetMenu(menuName = "Database/Spell Database")]
public class SpellDatabase : ScriptableObject
{
    [SerializeField]
    private Dictionary<int, Spell> spells;
    [SerializeField]
    private XMLDocumentReader xmlDocumentReader;
    [SerializeField]
    private int _moveLeftID;
    public int moveLeftID
    {
        get
        {
            return _moveLeftID;
        }
    }
    [SerializeField]
    private int _moveRightID;
    public int moveRightID
    {
        get
        {
            return _moveRightID;
        }
    }

    [SerializeField]
    private PlayerProfile playerProfile;

    [SerializeField]
    private Sprite moveLeftFemaleIcon;

    [SerializeField]
    private Sprite moveRightFemaleIcon;

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

        LoadXml(xmlDocumentReader.ReadXMLDocument());
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
                    spell.iconPath = element.Element("Icon").Value;
                    spell.icon = Resources.Load<Sprite>(spell.iconPath);
                }

                if (element.Elements("Action").Any())
                {
                    spell.actionPath = element.Element("Action").Value;
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
            spellCopy.iconPath = spell.iconPath;
            spellCopy.actionPath = spell.actionPath;
            return spellCopy;
        }
        else
        {
            return null;
        }
    }

    public Spell GetMoveLeft()
    {
        Spell spell = GetSpell(moveLeftID);
        if (spell != null)
        {
            if (playerProfile.gender == Gender.FEMALE)
            {
                spell.icon = moveLeftFemaleIcon;
            }
            return spell;
        }
        else
        {
            return null;
        }
    }

    public Spell GetMoveRight()
    {
        Spell spell = GetSpell(moveRightID);
        if (spell != null)
        {
            if (playerProfile.gender == Gender.FEMALE)
            {
                spell.icon = moveRightFemaleIcon;
            }
            return spell;
        }
        else
        {
            return null;
        }
    }
}
