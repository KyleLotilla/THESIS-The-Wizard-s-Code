using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipePanel : MonoBehaviour
{
    [SerializeField]
    private MaterialDatabase materialDatabase;
    [SerializeField]
    private SpellDatabase spellDatabase;
    [SerializeField]
    private List<DragNDropSpace> ingredientSpaces;
    [SerializeField]
    private GameObject materialSlotPrefab;
    [SerializeField]
    private GameObject resultSlot;
    [SerializeField]
    private GameObject resultSlotPrefab;
    [SerializeField]
    private GameObject resultSpace;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowRecipe(CraftingRecipe craftingRecipe)
    {
        Clear();
        if (craftingRecipe != null)
        {
            for (int i = 0; i < craftingRecipe.ingredientIDs.Count; i++)
            {
                Material ingredient = materialDatabase.GetMaterial(craftingRecipe.ingredientIDs[i]);
                if (ingredient != null)
                {
                    GameObject materialSlot = Instantiate(materialSlotPrefab, ingredientSpaces[i].transform);
                    ingredientSpaces[i].slot = materialSlot;
                    if (materialSlot != null)
                    {
                        MaterialInventorySlot materialInventorySlot = materialSlot.GetComponent<MaterialInventorySlot>();
                        if (materialInventorySlot != null)
                        {
                            materialInventorySlot.material = ingredient;
                        }
                    }
                }
            }

            Spell resultSpell = spellDatabase.GetSpell(craftingRecipe.resultSpellID);
            if (resultSpell != null)
            {
                resultSlot = Instantiate(resultSlotPrefab, resultSpace.transform);
                if (resultSlot != null)
                {
                    SpellInventorySlot resultInventorySlot = resultSlot.GetComponent<SpellInventorySlot>();
                    if (resultInventorySlot != null)
                    {
                        resultInventorySlot.spell = resultSpell;
                    }
                }
            }
        }
    }

    public void Clear()
    {
        foreach (DragNDropSpace space in ingredientSpaces)
        {
            if (space.slot != null)
            {
                DestroyImmediate(space.slot);
                space.slot = null;
            }
        }
        if (resultSlot != null)
        {
            DestroyImmediate(resultSlot.gameObject);
            resultSlot = null;
        }
    }
}
