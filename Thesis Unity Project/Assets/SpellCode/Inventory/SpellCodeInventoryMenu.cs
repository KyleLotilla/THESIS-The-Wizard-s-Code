using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.SpellCodes;

public delegate void OnSpellCodeSelected(SpellCode spellCode);

public class SpellCodeInventoryMenu : ItemSlotMenu<SpellCode>
{
    public event OnSpellCodeSelected OnSpellCodeSelected;
    [SerializeField]
    private SpellCodeInventory spellCodeInventory;
    [SerializeField]
    private SpellCodeInventoryPanel selected;
    // Start is called before the first frame update
    void Start()
    {
        /*
        items = spellCodeInventory;
        RefreshMenu();
        */
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
