using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DLSU.WizardCode.Spells;

public class ScriptableObjectTestScript : MonoBehaviour
{
    public SpellDatabase spellDatabase;
    public SpellInventory spellInventory;
    public SpellCodeInventory spellCodeInventory;
    public PlayerLevelProgression playerLevelProgression;
    public PlayerProfile playerProfile;
    // Start is called before the first frame update
    void Awake()
    {
        spellInventory.EquipSpell(spellDatabase.GetSpellInstance(1));
        //spellInventory.EquipSpell(fireBall);
        /*
            materialInventory.AddMaterial(materialDatabase.GetMaterial(2));
            materialInventory.AddMaterial(materialDatabase.GetMaterial(3));

            materialInventory.AddMaterial(materialDatabase.GetMaterial(0));
            materialInventory.AddMaterial(materialDatabase.GetMaterial(1));
            materialInventory.AddMaterial(materialDatabase.GetMaterial(1));

            Debug.Log(materialInventory.Count);

            Spell electro = spellDatabase.GetSpell(3);
            spellInventory.EquipSpell(electro);
        //}
        
        /*
        spellInventory.AddSpell(spellDatabase.GetSpell(4));
        spellInventory.AddSpell(spellDatabase.GetSpell(5));
        spellInventory.AddSpell(spellDatabase.GetSpell(2));
        */
        

       
        //spellInventory.AddSpell(electro);
        /*
        SpellCode spellCode2 = new SpellCode();
        spellCode2.AddSpell(spellDatabase.GetSpell(1));
        spellCode2.AddSpell(fireBall);
        spellCode2.AddSpell(electro);
        spellCode2.name = "Overload";
        spellCodeInventory.AddSpellCode(spellCode2);

        SpellCode spellCode1 = new SpellCode();
        spellCode1.AddSpell(fireBall);
        spellCode1.AddSpell(spellDatabase.GetSpell(1));
        spellCode1.AddSpell(spellDatabase.GetSpell(1));
        spellCode1.name = "Fire n' Forget";
        spellCodeInventory.EquipSpellCode(spellCode1);
        */
        /*
        for (int i = 0; i < 4; i++)
        {
            SpellCode spellCode2 = new SpellCode();
            spellCode2.AddSpell(spellDatabase.GetSpell(1));
            spellCode2.AddSpell(fireBall);
            spellCode2.AddSpell(electro);
            spellCode2.name = "Overload";
            spellCodeInventory.EquipSpellCode(spellCode2);
        }

        for (int i = 0; i < 3; i++)
        {
            SpellCode spellCode3 = new SpellCode();
            spellCode3.AddSpell(fireBall);
            spellCode3.AddSpell(spellDatabase.GetSpell(1));
            spellCode3.AddSpell(spellDatabase.GetSpell(1));
            spellCode3.name = "Fire n' Forget";
            spellCodeInventory.AddSpellCode(spellCode3);
        }
        */
        

        //playerProfile.gender = Gender.FEMALE;
        
        /*
        materialInventory.AddMaterial(materialDatabase.GetMaterial(0));
        materialInventory.AddMaterial(materialDatabase.GetMaterial(1));
        materialInventory.AddMaterial(materialDatabase.GetMaterial(1));
        materialInventory.AddMaterial(materialDatabase.GetMaterial(0));

        materialInventory.AddMaterial(materialDatabase.GetMaterial(2));

        for (int i = 0; i < 100; i++)
        materialInventory.AddMaterial(materialDatabase.GetMaterial(3));
        */

        /*
        LevelProgression levelProgression = new LevelProgression();
        levelProgression.levelID = 0;
        levelProgression.isUnlocked = true;
        levelProgression.highScore = 69;
        playerLevelProgression.AddProgression(levelProgression);
        */
        /*
        LevelProgression levelProgression1 = new LevelProgression();
        levelProgression1.levelID = 0;
       // levelProgression1.isUnlocked = true;
        levelProgression1.highScore = 700;
        playerLevelProgression.AddProgression(levelProgression1);
        */
    }

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
