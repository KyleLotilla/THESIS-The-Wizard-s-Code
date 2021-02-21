using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingArea : MonoBehaviour
{
    [SerializeField]
    private List<InventorySlotSpace> craftingSlotSpaces;
    [SerializeField]
    private InventorySlotSpace resultSlotSpace;
    [SerializeField]
    private SpellSlot resultSpellSlot;
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
        foreach (InventorySlotSpace slotSpace in craftingSlotSpaces)
        {
            slotSpace.OnSlotFilled += ShowResultSpell;
            slotSpace.OnSlotMove += ShowResultSpell;
        }
    }

    void ShowResultSpell(GameObject slot)
    {
        ShowResultSpell();
    }

    public void ShowResultSpell()
    {
        if (resultSlotSpace.slot != null)
        {
            resultSpellSlot = null;
            GameObject previousResultSlot = resultSlotSpace.slot;
            resultSlotSpace.EmptySlotSpace();
            DestroyImmediate(previousResultSlot);
        }
        ingredients = new List<Material>();

        foreach (InventorySlotSpace slotSpace in craftingSlotSpaces)
        {
            GameObject slot = slotSpace.slot;
            if (slot != null)
            {
                MaterialSlot materialSlot = slot.GetComponent<MaterialSlot>();
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
                    GameObject resultSpellObject = Instantiate(spellSlotTemplate, resultSlotSpace.transform);
                    resultSpellSlot = resultSpellObject.GetComponent<SpellSlot>();
                    if (resultSpellSlot != null)
                    {
                        resultSpellSlot.spell = resultSpell;
                        resultSpellSlot.isDraggable = false;
                        resultSlotSpace.FillSlotSpace(resultSpellObject);
                    }
                }
            }
        }
    }

    public void CraftSpell()
    {
        foreach (InventorySlotSpace slotSpace in craftingSlotSpaces)
        {
            GameObject slot = slotSpace.slot;
            slotSpace.EmptySlotSpace();
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


        resultSlotSpace.EmptySlotSpace();
        DestroyImmediate(resultSpellSlot.gameObject);
    }
}
