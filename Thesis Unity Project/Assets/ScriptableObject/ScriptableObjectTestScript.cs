using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DLSU.WizardCode.Spells;
using DLSU.WizardCode.SpellCodes;
using DLSU.WizardCode.Levels;

public class ScriptableObjectTestScript : MonoBehaviour
{
    public SpellDatabase spellDatabase;
    public SpellInventory spellInventory;
    public SpellCodeInventory spellCodeInventory;
    public LevelProgressionDatabase levelProgressionDatabase;
    public PlayerProfile playerProfile;
    // Start is called before the first frame update
    void Awake()
    {
        
        SpellInstance moveRight = spellDatabase.GetSpellInstance(1);
        SpellInstance fireball = spellDatabase.GetSpellInstance(5);
        SpellInstance electro = spellDatabase.GetSpellInstance(3);
        
        spellInventory.EquipSpellInstance(fireball);
        spellInventory.EquipSpellInstance(electro);

       
        SpellCode spellCode = new SpellCode();
        spellCode.Name = "Penny!";
        spellCode.AddSpellInstance(moveRight);
        spellCode.AddSpellInstance(fireball);
        spellCodeInventory.EquipSpellCode(spellCode);

        SpellCode spellCode2 = new SpellCode();
        spellCode2.Name = "Not Penny!";
        spellCode2.AddSpellInstance(electro);
        spellCode2.AddSpellInstance(moveRight);
        spellCode2.AddSpellInstance(fireball);
        spellCodeInventory.EquipSpellCode(spellCode2);
        /*
        LevelProgression levelProgression = new LevelProgression();
        levelProgression.LevelID = 0;
        levelProgression.HighScore = 3;
        levelProgressionDatabase.AddProgression(levelProgression);
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
