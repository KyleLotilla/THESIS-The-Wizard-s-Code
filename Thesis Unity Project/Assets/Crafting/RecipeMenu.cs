using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeMenu : MonoBehaviour
{
    [SerializeField]
    private CraftingDatabase craftingDatabase;
    [SerializeField]
    private SpellDatabase spellDatabase;
    [SerializeField]
    private GameObject recipeSlotPrefab;
    [SerializeField]
    private RecipePanel recipePanel;
    // Start is called before the first frame update
    void Start()
    {
        RefreshRecipes();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshRecipes()
    {
        RemoveAllSlots();
        foreach (CraftingRecipe craftingRecipe in craftingDatabase)
        {
            GameObject slot = Instantiate(recipeSlotPrefab, this.transform);
            Spell resultSpell = spellDatabase.GetSpell(craftingRecipe.resultSpellID);

            if (resultSpell != null)
            {
                SpellInventorySlot spellSlot = slot.GetComponent<SpellInventorySlot>();
                if (spellSlot != null)
                {
                    spellSlot.spell = resultSpell;
                }

                RecipeSlot recipeSlot = slot.GetComponent<RecipeSlot>();
                if (recipeSlot != null)
                {
                    recipeSlot.recipe = craftingRecipe;
                    recipeSlot.recipePanel = recipePanel;
                }
            }

        }
    }

    void RemoveAllSlots()
    {
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
