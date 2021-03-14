using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeSlot : MonoBehaviour
{
    public CraftingRecipe recipe { get; set; }
    public RecipePanel recipePanel { private get; set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowRecipe()
    {
        recipePanel.ShowRecipe(recipe);
    }
}
