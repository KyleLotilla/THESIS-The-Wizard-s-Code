using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DLSU.WizardCode.SpellCodes;

public class SpellCodeInventoryActionPanel : MonoBehaviour
{
    /*
    [SerializeField]
    private TabsPanel tabsPanel;
    */
    [SerializeField]
    private int spellCodeEditUIPage;
    [SerializeField]
    private SpellCodeEditUI spellCodeEditUI;
    [SerializeField]
    private SpellCodeInventoryMenu spellCodeInventoryMenu;
    [SerializeField]
    private SpellCodeEquipmentMenu spellCodeEquipmentMenu;
    [SerializeField]
    private SpellCodeEquippedCount spellCodeEquippedCount;
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
            /*
            if (spellCodeInventory.equippedCount >= spellCodeInventory.maxEquipped)
            {
                equipButton.interactable = false;
            }
            else if (!isEquipmentActions)
            {
                equipButton.interactable = value;
            }

            if (isTutorial)
            {
                foreach (Button button in buttons)
                {
                    button.interactable = false;
                }
            }
            else
            {
                foreach (Button button in buttons)
                {
                    button.interactable = _interactable;
                }
            }
            */
        }
    }
    [SerializeField]
    private Button equipButton;

    [SerializeField]
    private bool isEquipmentActions = false;

    [SerializeField]
    private bool isTutorial = false;
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
        //tabsPanel.SwitchPage(spellCodeEditUIPage);
    }

    public void EquipSpellCode()
    {
        spellCodeInventory.RemoveSpellCode(spellCode);
        spellCodeInventory.EquipSpellCode(spellCode);
        spellCodeInventoryMenu.RefreshMenu();
        spellCodeEquipmentMenu.RefreshMenu();
        spellCodeEquippedCount.Refresh();

        /*
        if (spellCodeInventory.equippedCount >= spellCodeInventory.maxEquipped)
        {
            equipButton.interactable = false;
        }
        */
        this.interactable = false;
    }

    public void UnequipSpellCode()
    {
        spellCodeInventory.UnequipSpellCode(spellCode);
        spellCodeInventory.AddSpellCode(spellCode);
        spellCodeInventoryMenu.RefreshMenu();
        spellCodeEquipmentMenu.RefreshMenu();
        spellCodeEquippedCount.Refresh();
        this.interactable = false;
    }

    public void EditSpellCode()
    {
        spellCodeEditUI.EnterEditMode(spellCode);
        //tabsPanel.SwitchPage(spellCodeEditUIPage);
    }

    public void RemoveSpellCode()
    {
        spellCodeInventory.RemoveSpellCode(spellCode);
        spellCodeInventoryMenu.RefreshMenu();
        spellCodeEquipmentMenu.RefreshMenu();
        spellCodeEquippedCount.Refresh();
        this.interactable = false;
    }
}
