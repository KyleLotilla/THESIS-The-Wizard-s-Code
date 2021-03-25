using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellCodeInventoryActionPanel : MonoBehaviour
{
    [SerializeField]
    private TabsPanel tabsPanel;
    [SerializeField]
    private int spellCodeEditUIPage;
    [SerializeField]
    private SpellCodeEditUI spellCodeEditUI;
    [SerializeField]
    private SpellCodeInventoryMenu spellCodeInventoryMenu;
    [SerializeField]
    private SpellCodeEquipmentMenu spellCodeEquipmentMenu;
    [SerializeField]
    private SpellCodeInventory spellCodeInventory;
    [SerializeField]
    private List<Button> buttons;
    [SerializeField]
    private bool _interactable = true;
    public bool interactable
    {
        get
        {
            return _interactable;
        }
        set
        {
            _interactable = value;
            foreach (Button button in buttons)
            {
                button.interactable = _interactable;
            }
        }
    }
    public SpellCode spellCode { get; set; }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddSpellCode()
    {
        spellCodeEditUI.EnterAddMode();
        tabsPanel.SwitchPage(spellCodeEditUIPage);
    }

    public void EquipSpellCode()
    {
        spellCodeInventory.RemoveSpellCode(spellCode);
        spellCodeInventory.EquipSpellCode(spellCode);
        spellCodeInventoryMenu.RefreshMenu();
        spellCodeEquipmentMenu.RefreshMenu();
    }

    public void UnequipSpellCode()
    {
        spellCodeInventory.UnequipSpellCode(spellCode);
        spellCodeInventory.AddSpellCode(spellCode);
        spellCodeInventoryMenu.RefreshMenu();
        spellCodeEquipmentMenu.RefreshMenu();
    }

    public void EditSpellCode()
    {
        spellCodeEditUI.EnterEditMode(spellCode);
        tabsPanel.SwitchPage(spellCodeEditUIPage);
    }

    public void RemoveSpellCode()
    {
        spellCodeInventory.RemoveSpellCode(spellCode);
        spellCodeInventoryMenu.RefreshMenu();
        spellCodeEquipmentMenu.RefreshMenu();
    }
}
