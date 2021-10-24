using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;
using DLSU.WizardCode.Spells;
using DLSU.WizardCode.SpellCodes;
using DLSU.WizardCode.Levels;

namespace DLSU.WizardCode.Save
{
    [CreateAssetMenu(menuName = "Save/SaveReader")]
    public class SaveReader : ScriptableObject
    {
        [SerializeField]
        private SaveWriter saveWriter;
        [SerializeField]
        private PlayerProfile playerProfile;
        [SerializeField]
        private SpellDatabase spellDatabase;
        [SerializeField]
        private SpellInventory spellInventory;
        [SerializeField]
        private SpellCodeInventory spellCodeInventory;
        [SerializeField]
        private LevelProgressionDatabase playerLevelProgression;

        private void OnEnable()
        {
            hideFlags = HideFlags.DontUnloadUnusedAsset;
        }

        public bool ReadSaveFile()
        {
            XDocument saveFileXDocument = ReadXMLDocument(Application.persistentDataPath + "/" + Application.version + "/" + "save.xml");
            if (saveFileXDocument != null)
            {
                ReadXML(saveFileXDocument);
                return true;
            }
            return false;
        }

        private void ReadXML(XDocument saveFileXDocument)
        {
            if (saveFileXDocument != null)
            {
                XElement root = saveFileXDocument.Root;
                ReadPlayerProfile(root);
                ReadSpellInventory(root);
                ReadSpellCodeInventory(root);
                ReadPlayerLevelProgression(root);
                saveWriter.SaveFileXDocument = saveFileXDocument;
            }
        }

        private void ReadPlayerProfile(XElement root)
        {
            if (root.Elements("Name").Any())
            {
                playerProfile.PlayerName = root.Element("Name").Value;
            }
            if (root.Elements("Gender").Any())
            {
                string gender = root.Element("Gender").Value;
                if (gender.Equals("MALE"))
                {
                    playerProfile.Gender = Gender.MALE;
                }
                else if (gender.Equals("FEMALE"))
                {
                    playerProfile.Gender = Gender.FEMALE;
                }
            }
            if (root.Elements("TutorialProgression").Any())
            {
                playerProfile.TutorialProgression = int.Parse(root.Element("TutorialProgression").Value);
            }
        }

        private void ReadSpellInventory(XElement root)
        {
            if (root.Elements("SpellInventory").Any())
            {
                XElement spellInventoryElement = root.Element("SpellInventory");

                if (spellInventoryElement.Elements("Equipped").Any())
                {
                    foreach (XElement spellElement in spellInventoryElement.Element("Equipped").Elements())
                    {
                        if (spellElement.Elements("ID").Any())
                        {
                            int spellID = int.Parse(spellElement.Element("ID").Value);
                            
                            SpellInstance spellInstance = spellDatabase.GetSpellInstance(spellID);
                            if (spellInstance != null)
                            {
                                spellInventory.EquipSpellInstance(spellInstance);
                            }
                            
                        }
                    }
                }

                if (spellInventoryElement.Elements("Inventory").Any())
                {
                    foreach (XElement spellElement in spellInventoryElement.Element("Inventory").Elements())
                    {
                        if (spellElement.Elements("ID").Any())
                        {
                            
                            int spellID = int.Parse(spellElement.Element("ID").Value);
                            SpellInstance spellInstance = spellDatabase.GetSpellInstance(spellID);
                            if (spellInstance != null)
                            {
                                spellInventory.AddUnequippedSpellInstance(spellInstance);
                            }
                        }
                    }
                }
            }
        }

        private void ReadSpellCodeInventory(XElement root)
        {
            if (root.Elements("SpellCodeInventory").Any())
            {
                XElement spellCodeInventoryElement = root.Element("SpellCodeInventory");

                if (spellCodeInventoryElement.Elements("Equipped").Any())
                {
                    foreach (XElement spellCodeElement in spellCodeInventoryElement.Element("Equipped").Elements())
                    {
                        SpellCode spellCode = new SpellCode();
                        spellCode.Name = spellCodeElement.Element("Name").Value;
                        foreach (XElement spellElement in spellCodeElement.Element("Spells").Elements())
                        {
                            int spellID = int.Parse(spellElement.Element("ID").Value);
                            SpellInstance spellInstance = spellInventory.GetEquippedSpellInstanceByID(spellID);
                            if (spellInstance == null)
                            {
                                spellInstance = spellInventory.GetUnequippedSpellInstanceByID(spellID);
                                if (spellInstance == null)
                                {
                                    spellInstance = spellDatabase.GetSpellInstance(spellID);
                                }
                            }
                            spellCode.AddSpellInstance(spellInstance);
                        }
                        spellCodeInventory.EquipSpellCode(spellCode);
                    }
                }

                if (spellCodeInventoryElement.Elements("Inventory").Any())
                {
                    foreach (XElement spellCodeElement in spellCodeInventoryElement.Element("Inventory").Elements())
                    {
                        SpellCode spellCode = new SpellCode();
                        spellCode.Name = spellCodeElement.Element("Name").Value;
                        foreach (XElement spellElement in spellCodeElement.Element("Spells").Elements())
                        {
                            int spellID = int.Parse(spellElement.Element("ID").Value);
                            SpellInstance spellInstance = spellInventory.GetEquippedSpellInstanceByID(spellID);
                            if (spellInstance == null)
                            {
                                spellInstance = spellInventory.GetUnequippedSpellInstanceByID(spellID);
                                if (spellInstance == null)
                                {
                                    spellInstance = spellDatabase.GetSpellInstance(spellID);
                                }
                            }
                            spellCode.AddSpellInstance(spellInstance);
                        }
                        spellCodeInventory.AddUnequippedSpellCode(spellCode);
                    }
                }
            }
        }

        private void ReadPlayerLevelProgression(XElement root)
        {
            if (root.Elements("PlayerLevelProgression").Any())
            {
                XElement playerLevelProgressionElement = root.Element("PlayerLevelProgression");
                foreach (XElement levelProgressionElement in playerLevelProgressionElement.Elements())
                {
                    if (levelProgressionElement.Elements("LevelID").Any())
                    {
                        LevelProgression levelProgression = new LevelProgression();
                        levelProgression.LevelID = int.Parse(levelProgressionElement.Element("LevelID").Value);
                        if (levelProgressionElement.Elements("HighScore").Any())
                        {
                            levelProgression.HighScore = int.Parse(levelProgressionElement.Element("HighScore").Value);
                        }
                        playerLevelProgression.AddProgression(levelProgression);
                    }
                }
            }
        }

        public string ImportPreviousFile()
        {
            string previousVersion = "0.0";
            List<string> directories = new List<string>(Directory.GetDirectories(Application.persistentDataPath));
            directories.Sort();
            bool foundPreviousFile = false;

            for (int i = directories.Count - 1; i >= 0 && !foundPreviousFile; i--)
            {
                directories[i] = directories[i].Replace("\\", "/");
                XDocument document = ReadXMLDocument(directories[i] + "/" + "save.xml");
                if (document != null)
                {
                    XElement root = document.Root;
                    if (root.Elements("Version").Any())
                    {
                        previousVersion = root.Element("Version").Value;
                    }
                    saveWriter.ImportPreviousFile(document);
                    ReadXML(document);
                    foundPreviousFile = true;
                }
            }

            return previousVersion;
        }

        private XDocument ReadXMLDocument(string xmlPath)
        {
            if (Directory.Exists(Path.GetDirectoryName(xmlPath)))
            {
                if (File.Exists(xmlPath))
                {
                    FileStream stream = new FileStream(xmlPath, FileMode.Open, FileAccess.Read);
                    XDocument document = XDocument.Load(stream);
                    stream.Close();
                    return document;
                }
            }
            return null;
        }
    }

}
