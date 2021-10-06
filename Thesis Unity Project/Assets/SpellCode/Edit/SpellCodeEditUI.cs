using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DLSU.WizardCode.Spells;
using DLSU.WizardCode.SpellCodes;

enum SpellCodeEditMode
{
    NONE,
    ADD,
    EDIT
}

public class SpellCodeEditUI : MonoBehaviour
{
    /*
    [SerializeField]
    private TabsPanel tabsPanel;
    */
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
    private SpellCodeEditMenu spellCodeEditMenu;
    [SerializeField]
    private SpellCodeSpellMenu spellMenu;
    [SerializeField]
    private SpellCodeEditSaveUI spellCodeEditSaveUI;
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
        spellCode.Name = "New SpellCode";
        spellCodePanel.spellCode = spellCode;
        spellCodeEditSaveUI.spaces = spellMenu.spaces;
        inputField.text = spellCode.Name;
        spellCodeEditMenu.RefreshMenu();
        spellCodeEditMode = SpellCodeEditMode.ADD;
    }

    public void EnterEditMode(SpellCode spellCode)
    {
        this.spellCode = spellCode;
        spellCodePanel.spellCode = spellCode;
        spellCodeEditSaveUI.spaces = spellMenu.spaces;
        inputField.text = spellCode.Name;
        spellCodeEditSaveUI.spaces = spellMenu.spaces;
        spellCodeEditMenu.RefreshMenu();
        spellCodeEditMode = SpellCodeEditMode.EDIT;
    }

    public void SaveSpellCode()
    {
        List<Spell> spells = new List<Spell>();
        foreach (GameObject spaceObject in spellMenu.spaces)
        {
            /*
            SlotSpace space = spaceObject.GetComponent<SlotSpace>();
            if (space != null)
            {
                GameObject slot = space.slot;
                if (slot != null)
                {
                    SpellSlot spellSlot = slot.GetComponent<SpellSlot>();
                    if (spellSlot != null)
                    {
                        spells.Add(spellSlot.spell);
                    }
                }
            }
            */
        }
        /*
        if (spells.Count >= spellCodeInventory.minSpells && inputField.text.Length > 0)
        {
            if (spellCodeEditMode == SpellCodeEditMode.ADD)
            {
                SpellCode newSpellCode = new SpellCode();
                newSpellCode.Name = inputField.text;
                foreach (Spell spell in spells)
                {
                    //newSpellCode.AddSpell(spell);
                }
                spellCodeInventory.AddSpellCode(newSpellCode);
                tabsPanel.SwitchPage(spellCodeInventoryPage);
            }
            else if (spellCodeEditMode == SpellCodeEditMode.EDIT)
            {
                spellCode.Name = inputField.text;
                spellCode.ClearSpells();
                foreach (Spell spell in spells)
                {
                    //spellCode.AddSpell(spell);
                }
                tabsPanel.SwitchPage(spellCodeInventoryPage);
            }
        }*/
    }

    public void DiscardSpellCode()
    {
        //tabsPanel.SwitchPage(spellCodeInventoryPage);
    }
}
