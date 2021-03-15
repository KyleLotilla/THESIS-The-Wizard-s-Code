using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentTab : MonoBehaviour
{
    [SerializeField]
    private int page;
    [SerializeField]
    private SpellInventoryMenu spellInventoryMenu;
    [SerializeField]
    private SpellEquippedMenu spellEquippedMenu;
    [SerializeField]
    private TabsPanel tabsPanel;

    // Start is called before the first frame update
    void Start()
    {
        tabsPanel.OnTabPageSwitch += OnTabPageSwitch;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTabPageSwitch(int page)
    {
        if (this.page == page)
        {
            spellInventoryMenu.RefreshInventory();
            spellEquippedMenu.RefreshEquipped();
        }
    }
}
