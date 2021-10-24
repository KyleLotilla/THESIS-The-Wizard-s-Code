﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DLSU.WizardCode.Spells;
using DLSU.WizardCode.SpellCodes;
using DLSU.WizardCode.Levels;
using DLSU.WizardCode.Save;

public class ScriptableObjectTestScript : MonoBehaviour
{
    public SpellDatabase spellDatabase;
    public SpellInventory spellInventory;
    public SpellCodeInventory spellCodeInventory;
    public LevelProgressionDatabase levelProgressionDatabase;
    public PlayerProfile playerProfile;
    public SaveWriter saveWriter;

    // Start is called before the first frame update
    void Awake()
    {
        
        SpellInstance moveRight = spellDatabase.GetSpellInstance(1);
        SpellInstance iceBeam = spellDatabase.GetSpellInstance(5);
        SpellInstance electro = spellDatabase.GetSpellInstance(3);
        SpellInstance fireball = spellDatabase.GetSpellInstance(2);
        
        spellInventory.EquipSpellInstance(fireball);
        spellInventory.AddUnequippedSpellInstance(electro);

        /*
        SpellCode spellCode = new SpellCode();
        spellCode.Name = "Sample SpellCode";
        spellCode.AddSpellInstance(moveRight);
        spellCode.AddSpellInstance(fireball);
        spellCode.AddSpellInstance(moveRight);
        spellCodeInventory.EquipSpellCode(spellCode);
        */

        /*
        SpellCode spellCode2 = new SpellCode();
        spellCode2.Name = "Not Penny!";
        spellCode2.AddSpellInstance(electro);
        spellCode2.AddSpellInstance(moveRight);
        spellCode2.AddSpellInstance(iceBeam);
        spellCodeInventory.AddUnequippedSpellCode(spellCode2);
        */

        /*
        for (int i = 0; i < 5; i++)
        {
            SpellCode spellCode3 = new SpellCode();
            spellCode3.Name = "Test";
            spellCode3.AddSpellInstance(electro);
            spellCode3.AddSpellInstance(moveRight);
            spellCodeInventory.AddUnequippedSpellCode(spellCode3);
        }
        */
        /*
        LevelProgression levelProgression = new LevelProgression();
        levelProgression.LevelID = 0;
        levelProgression.HighScore = 2;
        levelProgressionDatabase.AddProgression(levelProgression);
        */
        /*
        playerProfile.gender = Gender.FEMALE;
        playerProfile.tutorialProgression = 3;
        */
        saveWriter.CreateFile();
    }

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}