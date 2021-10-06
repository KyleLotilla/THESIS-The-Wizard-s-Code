using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DLSU.WizardCode.SpellCodes;

public class SpellCodePanel : MonoBehaviour
{
    [SerializeField]
    private SpellCodeInventory spellCodeInventory;
    [SerializeField]
    private GameObject spellInventorySlotPrefab;
    [SerializeField]
    private SpellCodeSpellMenu spellMenu;
    [SerializeField]
    private Text nameText;
    private SpellCode _spellCode;
    public SpellCode spellCode
    {
        get
        {
            return _spellCode;
        }
        set
        {
            _spellCode = value;
            RefreshPanel();
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshPanel()
    {
        /*
        spellMenu.maxSpaces = spellCodeInventory.maxSpells;
        
        spellMenu.spells = spellCode;
        nameText.text = spellCode.Name;
        */
    }

}
