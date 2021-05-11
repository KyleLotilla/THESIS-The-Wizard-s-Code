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

    public int getSize()
    {
        return pages.Count;
    }

    public void SwitchPage(int page)
    {
        if (page < pages.Count && page != currentPage)
        {
            if (currentPage >= 0)
            {
                pages[currentPage].SetActive(false);
            }

            if (page >= 0)
            {
                pages[page].SetActive(true);
            }
            currentPage = page;
            OnTabPageSwitch?.Invoke(page);
        }
    }

    public void OnDestroy()
    {
        OnTabPageSwitch = null;
    }
}
