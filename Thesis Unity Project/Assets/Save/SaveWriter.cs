using System.Linq;
using System.Xml.Linq;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using DLSU.WizardCode.Spells;
using DLSU.WizardCode.SpellCodes;

public class SaveWriter : MonoBehaviour
{
    [SerializeField]
    private XMLDocumentReader xmlDocumentReader;
    private XDocument _document;
    public XDocument document
    {
        get
        {
            return _document;
        }
        set
        {
            _document = value;
        }
    }
    [SerializeField]
    private PlayerProfile playerProfile;
    [SerializeField]
    private SpellDatabase spellDatabase;
    [SerializeField]
    private SpellInventory spellInventory;
    [SerializeField]
    private SpellCodeInventory spellCodeInventory;
    /*
    [SerializeField]
    private MaterialDatabase materialDatabase;
    [SerializeField]
    private MaterialInventory materialInventory;
    
    [SerializeField]
    private LevelProgressionDatabase playerLevelProgression;
    */

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SavePlayerProfile()
    {
        if (document != null)
        {
            XElement root = document.Root;
            if (root.Elements("Name").Any())
            {
                root.Element("Name").SetValue(playerProfile.playerName);
            }
            if (root.Elements("Gender").Any())
            {
                if (playerProfile.gender == Gender.MALE)
                {
                    root.Element("Gender").SetValue("MALE");
                }
                else if (playerProfile.gender == Gender.FEMALE)
                {
                    root.Element("Gender").SetValue("FEMALE");
                }
            }
            if (root.Elements("TutorialProgression").Any())
            {
                root.Element("TutorialProgression").SetValue(playerProfile.tutorialProgression.ToString());
            }
        }
    }

    private void SaveVersion()
    {
        if (document != null)
        {
            XElement root = document.Root;
            if (root.Elements("Version").Any())
            {
                root.Element("Version").SetValue(Application.version);
            }
        }
    }

    public void SaveSpellInventory()
    {
        if (document != null)
        {
            XElement newSpellInventory = new XElement("SpellInventory");

            XElement equippedElement = new XElement("Equipped");
            /*
            foreach (Spell spell in spellInventory.EquippedSpells)
            {
                XElement spellElement = new XElement("Spell");
                spellElement.Add(new XElement("ID", spell.spellID.ToString()));
                //spellElement.Add(new XElement("InstanceID", spell.instanceID.ToString()));
                equippedElement.Add(spellElement);
            }
            */
            newSpellInventory.Add(equippedElement);

            XElement inventoryElement = new XElement("Inventory");
            /*
            foreach (Spell spell in spellInventory)
            {
                XElement spellElement = new XElement("Spell");
                spellElement.Add(new XElement("ID", spell.spellID.ToString()));
                //spellElement.Add(new XElement("InstanceID", spell.instanceID.ToString()));
                inventoryElement.Add(spellElement);
            }
            */
            newSpellInventory.Add(inventoryElement);

            XElement root = document.Root;
            if (root.Elements("SpellInventory").Any())
            {
                XElement spellInventoryElement = root.Element("SpellInventory");
                spellInventoryElement.ReplaceWith(newSpellInventory);
            }
        }
    }

    public void SaveSpellCodeInventory()
    {
        if (document != null)
        {
            XElement newSpellCodeInventory = new XElement("SpellCodeInventory");

            XElement equippedElement = new XElement("Equipped");
            /*
            foreach (SpellCode spellCode in spellCodeInventory.equipped)
            {
                XElement spellCodeElement = new XElement("SpellCode");
                spellCodeElement.Add(new XElement("Name", spellCode.Name));
                XElement spellsElement = new XElement("Spells");
                
                foreach (Spell spell in spellCode)
                {
                    XElement spellElement = new XElement("Spell");
                    spellElement.Add(new XElement("ID", spell.SpellID.ToString()));
                   // spellElement.Add(new XElement("InstanceID", spell.instanceID.ToString()));
                    spellsElement.Add(spellElement);
                }
                
                spellCodeElement.Add(spellsElement);
                equippedElement.Add(spellCodeElement);
            }
            newSpellCodeInventory.Add(equippedElement);

            XElement inventoryElement = new XElement("Inventory");
            foreach (SpellCode spellCode in spellCodeInventory)
            {
                XElement spellCodeElement = new XElement("SpellCode");
                spellCodeElement.Add(new XElement("Name", spellCode.Name));
                XElement spellsElement = new XElement("Spells");
                /*
                foreach (Spell spell in spellCode)
                {
                    XElement spellElement = new XElement("Spell");
                    spellElement.Add(new XElement("ID", spell.SpellID.ToString()));
                    //spellElement.Add(new XElement("InstanceID", spell.instanceID.ToString()));
                    spellsElement.Add(spellElement);
                }
                
                spellCodeElement.Add(spellsElement);
                inventoryElement.Add(spellCodeElement);
            }
            newSpellCodeInventory.Add(inventoryElement);
            */
            XElement root = document.Root;
            if (root.Elements("SpellCodeInventory").Any())
            {
                XElement spellCodeInventoryElement = root.Element("SpellCodeInventory");
                spellCodeInventoryElement.ReplaceWith(newSpellCodeInventory);
            }
        }
    }

    public void SavePlayerLevelProgression()
    {
        if (document != null)
        {
            XElement newPlayerLevelProgression = new XElement("PlayerLevelProgression");
            /*
            foreach (LevelProgression levelProgression in playerLevelProgression)
            {
                XElement levelProgressionElement = new XElement("LevelProgression");
                levelProgressionElement.Add(new XElement("LevelID", levelProgression.levelID.ToString()));
                //levelProgressionElement.Add(new XElement("Unlocked", levelProgression.isUnlocked.ToString()));
                //levelProgressionElement.Add(new XElement("Completed", levelProgression.isCompleted.ToString()));
                levelProgressionElement.Add(new XElement("HighScore", levelProgression.highScore.ToString()));
                newPlayerLevelProgression.Add(levelProgressionElement);
            }
            */
            XElement root = document.Root;
            if (root.Elements("PlayerLevelProgression").Any())
            {
                XElement playerLevelProgressionElement = root.Element("PlayerLevelProgression");
                playerLevelProgressionElement.ReplaceWith(newPlayerLevelProgression);
            }
        }
    }

    public void SaveXMLFile()
    {
        XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
        xmlWriterSettings.Indent = true;
        string savePath = Application.persistentDataPath + "/" + Application.version + "/" + "save.xml";

        using (XmlWriter xmlWriter = XmlWriter.Create(savePath, xmlWriterSettings))
        {
            document.Save(xmlWriter);
        }
    }

    public void SaveFile()
    {
        if (document == null)
        {
            CreateFile();
        }

        SavePlayerProfile();
        SaveVersion();
        SaveSpellInventory();
        SaveSpellCodeInventory();
        SavePlayerLevelProgression();
        SaveXMLFile();
    }

    public void CreateFile()
    {
        document = xmlDocumentReader.ReadXMLDocument();
        SaveVersion();
        Directory.CreateDirectory(Application.persistentDataPath + "/" + Application.version);
        SaveXMLFile();
    }

    public void ImportPreviousFile(XDocument document)
    {
        this.document = document;
        SaveVersion();
        Directory.CreateDirectory(Application.persistentDataPath + "/" + Application.version);
        SaveXMLFile();
    }
}
