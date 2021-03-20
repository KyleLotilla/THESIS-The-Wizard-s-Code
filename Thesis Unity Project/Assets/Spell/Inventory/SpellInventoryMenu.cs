using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellInventoryMenu : ItemSlotMenu<Spell>
{
    [SerializeField]
    private SpellInventory spellInventory;
    // Start is called before the first frame update
    void Start()
    {
        items = spellInventory;
        RefreshMenu();
    }

    // Update is called once per frame
    void Update()
    {

    }

    override protected void OnSlotSpawn(GameObject slot, GameObject space, Spell item)
    {
        SpellInventorySlot spellInventorySlot = slot.GetComponent<SpellInventorySlot>();
        if (spellInventorySlot != null)
        {
            spellInventorySlot.spell = item;
        }
        DragNDropSpace dragNDropSpace = space.GetComponent<DragNDropSpace>();
        if (dragNDropSpace != null)
        {
            dragNDropSpace.slot = slot;
        }
    }
}
