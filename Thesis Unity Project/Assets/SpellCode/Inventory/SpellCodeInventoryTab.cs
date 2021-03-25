using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCodeInventoryTab : MonoBehaviour
{
    [SerializeField]
    private TabsPanel tabsPanel;
    [SerializeField]
    private int page;
    [SerializeField]
    private SpellCodeInventoryUI spellCodeInventoryUI;


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
        if (page == this.page)
        {
            spellCodeInventoryUI.RefreshUI();
        }
    }
}
