using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.SpellCodes;

public class SpellCodeEquipmentMenu : ItemSlotMenu<SpellCode>
{
    public event OnSpellCodeSelected OnSpellCodeSelected;
    [SerializeField]
    private SpellCodeInventory spellCodeInventory;
    [SerializeField]
    private SpellCodeInventoryPanel selected;
    [SerializeField]
    private List<Sprite> spellCodeIcons;
    private int spellCodeIconIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        /*
        items = spellCodeInventory.equipped;
        RefreshMenu();
        */
    }

    public override void RefreshMenu()
    {
        spellCodeIconIndex = 0;
        base.RefreshMenu();
    }

    protected override void OnSlotSpawn(GameObject slot, GameObject space, SpellCode item)
    {
        SpellCodePanel spellCodePanel = slot.GetComponent<SpellCodePanel>();
        if (spellCodePanel != null)
        {
            spellCodePanel.spellCode = item;
        }
        SpellCodeInventoryPanel spellCodeInventoryPanel = slot.GetComponent<SpellCodeInventoryPanel>();
        if (spellCodeInventoryPanel != null)
        {
            spellCodeInventoryPanel.spellCode = item;
            spellCodeInventoryPanel.OnSpellCodePanelSelected += OnSpellCodePanelSelected;
        }
        SpellCodeEquippedPanel spellCodeEquippedPanel = slot.GetComponent<SpellCodeEquippedPanel>();
        if (spellCodeEquippedPanel != null)
        {
            spellCodeEquippedPanel.icon = spellCodeIcons[spellCodeIconIndex];
            spellCodeIconIndex++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnSpellCodePanelSelected(SpellCodeInventoryPanel source, SpellCode spellCode)
    {
        UnselectMenu();
        selected = source;
        OnSpellCodeSelected?.Invoke(spellCode);
    }

    public void UnselectMenu()
    {
        if (selected != null)
        {
            selected.UnselectSpellCode();
            selected = null;
        }
    }
}
