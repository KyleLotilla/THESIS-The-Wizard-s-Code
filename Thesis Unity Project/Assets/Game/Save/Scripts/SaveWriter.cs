using System.Linq;
using System.Xml.Linq;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using DLSU.WizardCode.Spells;
using DLSU.WizardCode.SpellCodes;
using DLSU.WizardCode.Levels;

namespace DLSU.WizardCode.Save
{
    [CreateAssetMenu(menuName = "Save/SaveWriter")]
    public class SaveWriter : ScriptableObject
    {
        private XDocument saveFileXDocument;
        public XDocument SaveFileXDocument
        {
            get
            {
                return saveFileXDocument;
            }
            set
            {
                saveFileXDocument = value;
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
        [SerializeField]
        private LevelProgressionDatabase levelProgressionDatabase;
        [SerializeField]
        private TextAsset defaultSaveFileXML;

        private void OnEnable()
        {
            hideFlags = HideFlags.DontUnloadUnusedAsset;
        }

        public void SavePlayerProfile()
        {
            if (SaveFileXDocument != null)
            {
                XElement root = SaveFileXDocument.Root;
                if (root.Elements("Name").Any())
                {
                    root.Element("Name").SetValue(playerProfile.PlayerName);
                }
                if (root.Elements("Gender").Any())
                {
                    if (playerProfile.Gender == Gender.MALE)
                    {
                        root.Element("Gender").SetValue("MALE");
                    }
                    else if (playerProfile.Gender == Gender.FEMALE)
                    {
                        root.Element("Gender").SetValue("FEMALE");
                    }
                }
                if (root.Elements("TutorialProgression").Any())
                {
                    root.Element("TutorialProgression").SetValue(playerProfile.TutorialProgression.ToString());
                }
            }
        }

        private void SaveVersion()
        {
            if (SaveFileXDocument != null)
            {
                XElement root = SaveFileXDocument.Root;
                if (root.Elements("Version").Any())
                {
                    root.Element("Version").SetValue(Application.version);
                }
            }
        }

        public void SaveSpellInventory()
        {
            if (SaveFileXDocument != null)
            {
                XElement newSpellInventory = new XElement("SpellInventory");

                XElement equippedElement = new XElement("Equipped");
                foreach (SpellInstance spellInstance in spellInventory.EquippedSpellInstances)
                {
                    XElement spellElement = new XElement("Spell");
                    spellElement.Add(new XElement("ID", spellInstance.Spell.SpellID.ToString()));
                    equippedElement.Add(spellElement);
                }
                newSpellInventory.Add(equippedElement);

                XElement inventoryElement = new XElement("Inventory");
                
                foreach (SpellInstance spellInstance in spellInventory.UnequippedSpellInstances)
                {
                    XElement spellElement = new XElement("Spell");
                    spellElement.Add(new XElement("ID", spellInstance.Spell.SpellID.ToString()));
                    inventoryElement.Add(spellElement);
                }
                
                newSpellInventory.Add(inventoryElement);

                XElement root = SaveFileXDocument.Root;
                if (root.Elements("SpellInventory").Any())
                {
                    XElement spellInventoryElement = root.Element("SpellInventory");
                    spellInventoryElement.ReplaceWith(newSpellInventory);
                }
            }
        }

        public void SaveSpellCodeInventory()
        {
            if (SaveFileXDocument != null)
            {
                XElement newSpellCodeInventory = new XElement("SpellCodeInventory");

                XElement equippedElement = new XElement("Equipped");
                
                foreach (SpellCode spellCode in spellCodeInventory.EquippedSpellCodes)
                {
                    XElement spellCodeElement = new XElement("SpellCode");
                    spellCodeElement.Add(new XElement("Name", spellCode.Name));
                    XElement spellsElement = new XElement("Spells");

                    foreach (SpellInstance spellInstance in spellCode)
                    {
                        XElement spellElement = new XElement("Spell");
                        spellElement.Add(new XElement("ID", spellInstance.Spell.SpellID.ToString()));
                        spellsElement.Add(spellElement);
                    }
                    spellCodeElement.Add(spellsElement);
                    equippedElement.Add(spellCodeElement);
                }
                newSpellCodeInventory.Add(equippedElement);

                XElement inventoryElement = new XElement("Inventory");
                foreach (SpellCode spellCode in spellCodeInventory.UnequippedSpellCodes)
                {
                    XElement spellCodeElement = new XElement("SpellCode");
                    spellCodeElement.Add(new XElement("Name", spellCode.Name));
                    XElement spellsElement = new XElement("Spells");
                    foreach (SpellInstance spellInstance in spellCode)
                    {
                        XElement spellElement = new XElement("Spell");
                        spellElement.Add(new XElement("ID", spellInstance.Spell.SpellID.ToString()));
                        spellsElement.Add(spellElement);
                    }
                    spellCodeElement.Add(spellsElement);
                    inventoryElement.Add(spellCodeElement);
                }
                newSpellCodeInventory.Add(inventoryElement);
                
                XElement root = SaveFileXDocument.Root;
                if (root.Elements("SpellCodeInventory").Any())
                {
                    XElement spellCodeInventoryElement = root.Element("SpellCodeInventory");
                    spellCodeInventoryElement.ReplaceWith(newSpellCodeInventory);
                }
            }
        }

        public void SaveLevelProgression()
        {
            if (SaveFileXDocument != null)
            {
                XElement newPlayerLevelProgression = new XElement("PlayerLevelProgression");
                
                foreach (LevelProgression levelProgression in levelProgressionDatabase)
                {
                    XElement levelProgressionElement = new XElement("LevelProgression");
                    levelProgressionElement.Add(new XElement("LevelID", levelProgression.LevelID.ToString()));
                    levelProgressionElement.Add(new XElement("HighScore", levelProgression.HighScore.ToString()));
                    newPlayerLevelProgression.Add(levelProgressionElement);
                }

                XElement root = SaveFileXDocument.Root;
                if (root.Elements("PlayerLevelProgression").Any())
                {
                    XElement playerLevelProgressionElement = root.Element("PlayerLevelProgression");
                    playerLevelProgressionElement.ReplaceWith(newPlayerLevelProgression);
                }
            }
        }

        public void SaveXMLFile()
        {
            if (saveFileXDocument != null)
            {
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.Indent = true;
                string savePath = Application.persistentDataPath + "/" + Application.version + "/" + "save.xml";

                using (XmlWriter xmlWriter = XmlWriter.Create(savePath, xmlWriterSettings))
                {
                    saveFileXDocument.Save(xmlWriter);
                }
            }
        }

        public void SaveFile()
        {
            if (SaveFileXDocument == null)
            {
                CreateFile();
            }
            SavePlayerProfile();
            SaveVersion();
            SaveSpellInventory();
            SaveSpellCodeInventory();
            SaveLevelProgression();
            SaveXMLFile();
        }

        public void CreateFile()
        {
            MemoryStream stream = new MemoryStream(defaultSaveFileXML.bytes);
            SaveFileXDocument = XDocument.Load(stream);
            stream.Close();
            SaveVersion();
            Directory.CreateDirectory(Application.persistentDataPath + "/" + Application.version);
            SaveXMLFile();
        }

        public void ImportPreviousFile(XDocument saveFileXDocument)
        {
            SaveFileXDocument = saveFileXDocument;
            SaveVersion();
            Directory.CreateDirectory(Application.persistentDataPath + "/" + Application.version);
            SaveXMLFile();
        }
    }

}
