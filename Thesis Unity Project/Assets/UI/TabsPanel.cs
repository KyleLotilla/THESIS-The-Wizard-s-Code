using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnTabPageSwitch(int page);

public class TabsPanel : MonoBehaviour
{
    public event OnTabPageSwitch OnTabPageSwitch;

    [SerializeField]
    private List<GameObject> pages;
    [SerializeField]
    private int currentPage;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SwitchPage(int page)
    {
        if (page >= 0 && page < pages.Count && page != currentPage)
        {
            pages[currentPage].SetActive(false);
            pages[page].SetActive(true);
            currentPage = page;
            OnTabPageSwitch?.Invoke(page);
        }
    }

    public void OnDestroy()
    {
        OnTabPageSwitch = null;
    }
}
