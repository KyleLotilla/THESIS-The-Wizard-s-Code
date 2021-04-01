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
        SpellSlot spellSpell = slot.GetComponent<SpellSlot>();
        if (spellSpell != null)
        {
            spellSpell.spell = item;
        }
        if (space != null)
        {
            SlotSpace slotSpace = space.GetComponent<SlotSpace>();
            if (slotSpace != null)
            {
                slotSpace.slot = slot;
            }
        }
    }
}
