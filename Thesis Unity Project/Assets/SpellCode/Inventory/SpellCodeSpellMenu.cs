using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Spells;

public class SpellCodeSpellMenu : ItemSlotMenu<Spell>
{
    public IEnumerable<Spell> spells
    {
        set
        {
            items = value;
            RefreshMenu();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
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
        /*
        SlotSpace slotSpace = space.GetComponent<SlotSpace>();
        if (slotSpace != null)
        {
            slotSpace.slot = slot;
        }
        */
    }
}
