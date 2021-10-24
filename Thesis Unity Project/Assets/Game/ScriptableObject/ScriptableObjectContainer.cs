using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Spells;
using DLSU.WizardCode.SpellCodes;
using DLSU.WizardCode.Levels;
using DLSU.WizardCode.Save;

public class ScriptableObjectContainer : MonoBehaviour
{
    public SpellDatabase spellDatabase;
    public SpellInventory spellInventory;
    public SpellCodeInventory spellCodeInventory;
    public LevelDatabase levelDatabase;
    public LevelProgressionDatabase playerLevelProgression;
    public PlayerProfile playerProfile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
