using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellEquipmentMenu : ItemSlotMenu<Spell>
{
    [SerializeField]
    private SpellInventory spellInventory;
    // Start is called before the first frame update
    void Start()
    {
        items = spellInventory.equipped;
        maxSpaces = spellInventory.maxEquipped;
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
        if (space != null)
        {
            DragNDropSpace dragNDropSpace = space.GetComponent<DragNDropSpace>();
            if (dragNDropSpace != null)
            {
                dragNDropSpace.slot = slot;
            }
            SpellEquipmentSpace spellEquipmentSpace = space.GetComponent<SpellEquipmentSpace>();
            if (spellEquipmentSpace != null)
            {
                spellEquipmentSpace.spell = item;
            }
        }
    }
}
