using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeMenu : ItemSlotMenu<CraftingRecipe>
{
    [SerializeField]
    private CraftingDatabase craftingDatabase;
    [SerializeField]
    private SpellDatabase spellDatabase;
    [SerializeField]
    private RecipePanel recipePanel;
    // Start is called before the first frame update
    void Start()
    {
        items = craftingDatabase;
        RefreshMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnSlotSpawn(GameObject slot, GameObject space, CraftingRecipe item)
    {
        Spell resultSpell = spellDatabase.GetSpell(item.resultSpellID);

        if (resultSpell != null)
        {
            SpellSlot spellSlot = slot.GetComponent<SpellSlot>();
            if (spellSlot != null)
            {
                spellSlot.spell = resultSpell;
            }

            RecipeSlot recipeSlot = slot.GetComponent<RecipeSlot>();
            if (recipeSlot != null)
            {
                recipeSlot.recipe = item;
                recipeSlot.recipePanel = recipePanel;
            }
        }
    }
}
