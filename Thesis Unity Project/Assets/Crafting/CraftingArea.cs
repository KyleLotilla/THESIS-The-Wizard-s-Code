using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingArea : MonoBehaviour
{
    [SerializeField]
    private List<InventoryDropSpace> craftingSlotSpaces;
    [SerializeField]
    private InventoryDropSpace resultDropSpace;
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
    private GameObject spellSlotTemplate;
    private List<Material> ingredients;
    // Start is called before the first frame update
    void Start()
    {
        foreach (InventoryDropSpace dropSpace in craftingSlotSpaces)
        {
            dropSpace.OnSlotFilled += ShowResultSpell;
            dropSpace.OnSlotEmpty += ShowResultSpell;
        }
    }

    void ShowResultSpell(GameObject slot)
    {
        ShowResultSpell();
    }

    public void ShowResultSpell()
    {
        if (resultDropSpace.slot != null)
        {
            resultSpellSlot = null;
            GameObject previousResultSlot = resultDropSpace.slot;
            resultDropSpace.slot = null;
            DestroyImmediate(previousResultSlot);
        }
        ingredients = new List<Material>();

        foreach (InventoryDropSpace slotSpace in craftingSlotSpaces)
        {
            GameObject slot = slotSpace.slot;
            if (slot != null)
            {
                MaterialInventorySlot materialSlot = slot.GetComponent<MaterialInventorySlot>();
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
                    GameObject resultSpellObject = Instantiate(spellSlotTemplate, resultDropSpace.transform);
                    resultSpellSlot = resultSpellObject.GetComponent<SpellInventorySlot>();
                    if (resultSpellSlot != null)
                    {
                        resultSpellSlot.spell = resultSpell;
                        resultSpellSlot.isDraggable = false;
                        resultDropSpace.slot = resultSpellObject;
                    }
                }
            }
        }
    }

    public void CraftSpell()
    {
        foreach (InventoryDropSpace slotSpace in craftingSlotSpaces)
        {
            GameObject slot = slotSpace.slot;
            slotSpace.slot = null;
            if (slot != null)
            {
                DestroyImmediate(slot);
            }
        }

        foreach(Material material in ingredients)
        {
            materialInventory.RemoveMaterial(material);
        }

        if (resultSpellSlot != null)
        {
            if (resultSpellSlot.spell != null)
            {
                spellInventory.AddSpell(resultSpellSlot.spell);
            }
        }


        resultDropSpace.slot = null;
        DestroyImmediate(resultSpellSlot.gameObject);
    }
}
