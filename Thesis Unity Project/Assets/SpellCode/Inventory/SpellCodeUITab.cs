using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCodeUITab : MonoBehaviour
{
    [SerializeField]
    private int outerPage;
    [SerializeField]
    private int innerPage;
    /*
    [SerializeField]
    private TabsPanel outerTabsPanel;
    [SerializeField]
    private TabsPanel innerTabsPanel;
    */
    [SerializeField]
    private SpellCodeInventoryUI spellCodeInventoryUI;

    // Start is called before the first frame update
    void Start()
    {
        //outerTabsPanel.OnTabPageSwitch += OnTabPageSwitch;
    }

    private void OnTabPageSwitch(int page)
    {
        if (page == outerPage)
        {
            //innerTabsPanel.SwitchPage(innerPage);
            spellCodeInventoryUI.RefreshUI();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
