using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.SpellCodes;

public class SpellCodeInventoryUI : MonoBehaviour
{
    [SerializeField]
    private SpellCodeEquipmentMenu spellCodeEquipmentMenu;
    [SerializeField]
    private SpellCodeInventoryMenu spellCodeInventoryMenu;
    [SerializeField]
    private SpellCodeInventoryActionPanel equipmentActionPanel;
    [SerializeField]
    private SpellCodeInventoryActionPanel inventoryActionPanel;
    // Start is called before the first frame update
    void Start()
    {
        spellCodeEquipmentMenu.OnSpellCodeSelected += OnEqiupmentSelected;
        spellCodeInventoryMenu.OnSpellCodeSelected += OnInventorySelected;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshUI()
    {
        equipmentActionPanel.interactable = false;
        inventoryActionPanel.interactable = false;
        spellCodeEquipmentMenu.RefreshMenu();
        spellCodeInventoryMenu.RefreshMenu();
    }

    void OnInventorySelected(SpellCode spellCode)
    {
        inventoryActionPanel.interactable = true;
        inventoryActionPanel.spellCode = spellCode;
        equipmentActionPanel.interactable = false;
        equipmentActionPanel.spellCode = null;
        spellCodeEquipmentMenu.UnselectMenu();
    }

    void OnEqiupmentSelected(SpellCode spellCode)
    {
        equipmentActionPanel.interactable = true;
        equipmentActionPanel.spellCode = spellCode;
        inventoryActionPanel.interactable = false;
        inventoryActionPanel.spellCode = null;
        spellCodeInventoryMenu.UnselectMenu();
    }
}
