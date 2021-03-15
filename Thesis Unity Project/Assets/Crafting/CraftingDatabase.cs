using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;
using System.IO;

public class CraftingDatabase : XMLDatabaseComponent, IEnumerable
{
    private Dictionary<string, int> recipes;
    /* The key is the ingredients for the recipes. It is represented through a formatted string of space-separed integer ids of the ingredients.
     * For Example: "1 2" indicates that items with ids 1 and 2 are the ingredients needed for the recipe.
     * The value is the result of the recipe. It is represented by the id of the resulting item.
     * 
     */
    private List<CraftingRecipe> recipesList;

    [SerializeField]
    private string pathToXMLDatabase;

    public void OnEnable()
    {
        if (recipes != null)
        {
            recipes.Clear();
        }
        else
        {
            recipes = new Dictionary<string, int>();
            recipesList = new List<CraftingRecipe>();
        }

        LoadXml(LoadLocalXmlDocument(pathToXMLDatabase));
    }

    void LoadXml(XDocument document)
    {
        XElement root = document.Root;
        foreach (XElement recipe in root.Elements())
        {
            if (recipe.Elements("Ingredients").Any() && recipe.Elements("Result").Any())
            {
                List<int> ingredentIDs = new List<int>();
                string ingredientString = "";
                foreach (XElement ingredientID in recipe.Element("Ingredients").Elements())
                {
                    if (ingredientString.Length > 0)
                    {
                        ingredientString += " ";
                    }
                    ingredientString += ingredientID.Value;
                    ingredentIDs.Add(int.Parse(ingredientID.Value));
                }
                int resultID = int.Parse(recipe.Element("Result").Value);
                recipes.Add(ingredientString, resultID);
                CraftingRecipe craftingRecipe = new CraftingRecipe();
                craftingRecipe.resultSpellID = resultID;
                craftingRecipe.ingredientIDs = ingredentIDs;
                recipesList.Add(craftingRecipe);
            }
        }
    }

    public int CraftIngredients(List<Material> ingredients)
    {
        String ingredientString = "";

        IEnumerable<Material> orderedIngredients = ingredients.OrderBy(material => material.materialID);

        foreach(Material ingredient in orderedIngredients)
        {
            if (ingredientString.Length > 0)
            {
                ingredientString += " ";
            }
            ingredientString += ingredient.materialID;
        }

        if (recipes.ContainsKey(ingredientString))
        {
            return recipes[ingredientString];
        }
        else
        {
            return -1;
        }
    }

    public IEnumerator GetEnumerator()
    {
        return ((IEnumerable)recipesList).GetEnumerator();
    }
}
