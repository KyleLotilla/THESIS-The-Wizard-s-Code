using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;
using DLSU.WizardCode.Spells;
using DLSU.WizardCode.SpellCodes;

public class SaveReader : MonoBehaviour
{
    [SerializeField]
    private XMLDocumentReader xmlDocumentReader;
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
        //ReadSaveFile();
        /*
        Spell spell = spellDatabase.GetSpell(4);
        spellInventory.EquipSpell(spell);
        SpellCode spellCode = new SpellCode();
        spellCode.name = "Test3";
        spellCode.AddSpell(spell);
        spellCode.AddSpell(spell); 
        spellCode.AddSpell(spellDatabase.GetSpell(spellDatabase.moveLeftID, Guid.Empty));
        spellCodeInventory.EquipSpellCode(spellCode);
        saveWriter.SaveSpellInventory();
        saveWriter.SaveSpellCodeInventory();
        materialInventory.AddMaterial(materialDatabase.GetMaterial(0));
        saveWriter.SaveMaterialInventory();
        LevelProgression levelProgression = new LevelProgression();
        levelProgression.levelID = 2;
        levelProgression.isUnlocked = true;
        levelProgression.isCompleted = false;
        levelProgression.highScore = 0;
        playerLevelProgression.AddProgression(levelProgression);
        saveWriter.SavePlayerLevelProgression();
        */
        //playerProfile.playerName = "Yes";
        //playerProfile.gender = Gender.MALE;
        //saveWriter.SavePlayerProfile();
        //saveWriter.SaveFile();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool ReadSaveFile()
    {
        XDocument document = xmlDocumentReader.ReadXMLDocument(Application.persistentDataPath + "/" + Application.version + "/" + "save.xml");
        if (document != null)
        {
            ReadXML(document);
            return true;
        }
        return false;
    }

    private void ReadXML(XDocument document)
    {
        if (document != null)
        {
            XElement root = document.Root;
            ReadPlayerProfile(root);
            ReadSpellInventory(root);
            ReadSpellCodeInventory(root);
            ReadPlayerLevelProgression(root);
            saveWriter.document = document;
        }
    }

    private void ReadPlayerProfile(XElement root)
    {
        if (root.Elements("Name").Any())
        {
            playerProfile.playerName = root.Element("Name").Value;
        }
        if (root.Elements("Gender").Any())
        {
            string gender = root.Element("Gender").Value;
            if (gender.Equals("MALE"))
            {
                playerProfile.gender = Gender.MALE;
            }
            else if (gender.Equals("FEMALE"))
            {
                playerProfile.gender = Gender.FEMALE;
            }
        }
        if (root.Elements("TutorialProgression").Any())
        {
            playerProfile.tutorialProgression = int.Parse(root.Element("TutorialProgression").Value);
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
                        /*
                        Spell spell = spellDatabase.GetSpell(spellID);
                        if (spell != null)
                        {
                            //spellInventory.EquipSpell(spell);
                        }
                        */
                    }
                }
            }

            if (spellInventoryElement.Elements("Inventory").Any())
            {
                foreach (XElement spellElement in spellInventoryElement.Element("Inventory").Elements())
                {
                    if (spellElement.Elements("ID").Any())
                    {
                        /*
                        int spellID = int.Parse(spellElement.Element("ID").Value);
                        Spell spell = spellDatabase.GetSpell(spellID);
                        if (spell != null)
                        {
                          //spellInventory.AddSpell(spell);
                        }
                        */
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
                        /*
                        if (spellID == spellDatabase.moveLeftID)
                        {
                            spellCode.AddSpell(spellDatabase.GetMoveLeft());
                        }
                        else if (spellID == spellDatabase.moveRightID)
                        {
                            spellCode.AddSpell(spellDatabase.GetMoveRight());
                        }
                        else
                        {
                            spellCode.AddSpell(spellDatabase.GetSpell(spellID));
                        }
                        */
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
                        //spellCode.AddSpell(spellDatabase.GetSpell(spellID));
                    }
                    spellCodeInventory.AddSpellCode(spellCode);
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
                    /*
                    LevelProgression levelProgression = new LevelProgression();
                    levelProgression.levelID = int.Parse(levelProgressionElement.Element("LevelID").Value);
                    if (levelProgressionElement.Elements("HighScore").Any())
                    {
                        levelProgression.highScore = int.Parse(levelProgressionElement.Element("HighScore").Value);
                    }
                    playerLevelProgression.AddProgression(levelProgression);
                    */
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

        for(int i = directories.Count - 1; i >= 0  && !foundPreviousFile; i--)
        {
            directories[i] = directories[i].Replace("\\", "/");
            XDocument document = xmlDocumentReader.ReadXMLDocument(directories[i] + "/" + "save.xml");
            if (document !=  null)
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
}
