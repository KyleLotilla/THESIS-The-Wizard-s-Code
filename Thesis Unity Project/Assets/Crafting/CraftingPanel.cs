using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingPanel : MonoBehaviour
{
    [SerializeField]
    private List<DragNDropSpace> craftingSpaces;
    [SerializeField]
    private GameObject resultSpace;
    [SerializeField]
    private SpellInventorySlot resultSpellSlot;
    [SerializeField]
    private CraftingDatabase craftingDatabase;
    [SerializeField]
    private SpellDatabase spellDatabase;
    [SerializeField]
    private MaterialInventory materialInventory;
    [SerializeField]
    private SpellInventory spellInventory;
    [SerializeField]
    private GameObject resultSlotPrefab;
    private List<Material> ingredients;
    // Start is called before the first frame update
    void Start()
    {
        foreach (DragNDropSpace space in craftingSpaces)
        {
            space.OnSlotChange += ShowResultSpell;
        }
    }

    public void ShowResultSpell(GameObject slot)
    {
        if (resultSpellSlot != null)
        {
            DestroyImmediate(resultSpellSlot.gameObject);
            resultSpellSlot = null;
        }
        ingredients = new List<Material>();

        foreach (DragNDropSpace space in craftingSpaces)
        {
            GameObject spaceSlot = space.slot;
            if (spaceSlot != null)
            {
                MaterialInventorySlot materialSlot = spaceSlot.GetComponent<MaterialInventorySlot>();
                if (materialSlot != null)
                {
                    if (materialSlot.material != null)
                    {
                        ingredients.Add(materialSlot.material);
                    }
                }
            }
        }

        if (ingredients.Count > 1)
        {
            int result = craftingDatabase.CraftIngredients(ingredients);
            if (result >= 0)
            {
                Spell resultSpell = spellDatabase.GetSpell(result);
                if (resultSpell != null)
                {
                    GameObject resultSpellObject = Instantiate(resultSlotPrefab, resultSpace.transform);
                    resultSpellSlot = resultSpellObject.GetComponent<SpellInventorySlot>();
                    if (resultSpellSlot != null)
                    {
                        resultSpellSlot.spell = resultSpell;
                    }
                }
            }
        }
    }

    public void CraftSpell()
    {        
        if (resultSpellSlot != null)
        {
            if (resultSpellSlot.spell != null)
            {
                spellInventory.AddSpell(resultSpellSlot.spell);
            }
        }

        DestroyImmediate(resultSpellSlot.gameObject);

        foreach (DragNDropSpace space in craftingSpaces)
        {
            DestroyImmediate(space.slot);
            space.slot = null;
        }

        foreach (Material material in ingredients)
        {
            materialInventory.RemoveMaterial(material);
        }

    }
}
