﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum SpellCodeEditMode
{
    NONE,
    ADD,
    EDIT
}

public class SpellCodeEditUI : MonoBehaviour
{
    [SerializeField]
    private TabsPanel tabsPanel;
    [SerializeField]
    private int spellCodeInventoryPage;
    [SerializeField]
    private SpellCode spellCode;
    [SerializeField]
    private SpellCodeEditMode spellCodeEditMode;
    [SerializeField]
    private InputField inputField; 
    [SerializeField]
    private SpellCodePanel spellCodePanel;
    [SerializeField]
    private SpellCodeSpellMenu spellMenu;
    [SerializeField]
    private SpellCodeInventory spellCodeInventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterAddMode()
    {
        spellCode = new SpellCode();
        spellCode.name = "New SpellCode";
        spellCodePanel.spellCode = spellCode;
        inputField.text = spellCode.name;
        spellCodeEditMode = SpellCodeEditMode.ADD;
    }

    public void EnterEditMode(SpellCode spellCode)
    {
        this.spellCode = spellCode;
        spellCodePanel.spellCode = spellCode;
        inputField.text = spellCode.name;
        spellCodeEditMode = SpellCodeEditMode.EDIT;
    }

    public void SaveSpellCode()
    {
        List<Spell> spells = new List<Spell>();
        foreach (DragNDropSpace space in spellMenu.spaces)
        {
            GameObject slot = space.slot;
            if (slot != null)
            {
                SpellInventorySlot spellInventorySlot = slot.GetComponent<SpellInventorySlot>();
                if (spellInventorySlot != null)
                {
                    spells.Add(spellInventorySlot.spell);
                }
            }
        }

        if (spells.Count >= spellCodeInventory.minSpells && inputField.text.Length > 0)
        {
            if (spellCodeEditMode == SpellCodeEditMode.ADD)
            {
                SpellCode newSpellCode = new SpellCode();
                newSpellCode.name = inputField.text;
                foreach (Spell spell in spells)
                {
                    newSpellCode.AddSpell(spell);
                }
                spellCodeInventory.AddSpellCode(newSpellCode);
                tabsPanel.SwitchPage(spellCodeInventoryPage);
            }
            else if (spellCodeEditMode == SpellCodeEditMode.EDIT)
            {
                spellCode.name = inputField.text;
                spellCode.ClearSpells();
                foreach (Spell spell in spells)
                {
                    spellCode.AddSpell(spell);
                }
                tabsPanel.SwitchPage(spellCodeInventoryPage);
            }
        }
    }
}