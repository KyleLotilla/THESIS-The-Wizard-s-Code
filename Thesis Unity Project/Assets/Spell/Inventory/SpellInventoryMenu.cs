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
        SpellSlot spellSlot = slot.GetComponent<SpellSlot>();
        if (spellSlot != null)
        {
            spellSlot.spell = item;
        }
        SlotSpace slotSpace = space.GetComponent<SlotSpace>();
        if (slotSpace != null)
        {
            slotSpace.slot = slot;
        }
    }
}
