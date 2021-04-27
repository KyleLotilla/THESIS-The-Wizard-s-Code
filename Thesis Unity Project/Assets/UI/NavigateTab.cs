using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigateTab : MonoBehaviour
{
    [SerializeField]
    private TabsPanel tabspanel;

    [SerializeField]
    private TabButton leftTabButton;

    [SerializeField]
    private TabButton rightTabButton;

    [SerializeField]
    private Button leftbutton;

    [SerializeField]
    private Button rightbutton;

    // Start is called before the first frame update


    void Start()
    {
        tabspanel.OnTabPageSwitch += onTabSwitch;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onTabSwitch(int page)
    {
        if(page == 0)
        {
            leftbutton.interactable = false;
        }
        else
        {
            leftTabButton.page = page - 1;
            leftbutton.interactable = true;
        }
        
        if(page == tabspanel.getSize() - 1)
        {
            rightbutton.interactable = false;
        }
        else
        {
            rightTabButton.page = page + 1;
            rightbutton.interactable = true;
        }
        
    }
}
