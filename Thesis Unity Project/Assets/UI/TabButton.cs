using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabButton : MonoBehaviour
{
    [SerializeField]
    private TabsPanel tabsPanel;
    [SerializeField]
    private int page;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchPage()
    {
        tabsPanel.SwitchPage(page);
    }
}
