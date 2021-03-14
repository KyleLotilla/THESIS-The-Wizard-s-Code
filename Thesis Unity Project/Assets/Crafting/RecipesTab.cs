using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipesTab : MonoBehaviour
{
    [SerializeField]
    private int page;
    [SerializeField]
    RecipePanel recipePanel;
    [SerializeField]
    RecipeMenu recipeMenu;
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
            recipePanel.Clear();
            recipeMenu.RefreshRecipes();
        }
    }
}
