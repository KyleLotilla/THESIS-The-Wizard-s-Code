using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpellCodeEditMenu : ItemSlotMenu<Spell>
{
    [SerializeField]
    private SpellInventory spellInventory;
    [SerializeField]
    private SpellDatabase spellDatabase;
    [SerializeField]
    private int moveLeftID;
    [SerializeField]
    private int moveRightID;
    // Start is called before the first frame update
    void Start()
    {
        List<Spell> spells = spellInventory.fullInventory.ToList();
        Spell moveLeftSpell = spellDatabase.GetSpell(moveLeftID);
        if (moveLeftSpell != null)
        {
            spells.Insert(0, moveLeftSpell);
        }
        Spell moveRightSpell = spellDatabase.GetSpell(moveRightID);
        if (moveRightSpell != null)
        {
            spells.Insert(1, moveRightSpell);
        }
        items = spells;
        RefreshMenu();
    }

    // Update is called once per frame
    void Update()
    {

    }

    override protected void OnSlotSpawn(GameObject slot, GameObject space, Spell item)
    {
        SpellSlot spellInventorySlot = slot.GetComponent<SpellSlot>();
        if (spellInventorySlot != null)
        {
            spellInventorySlot.spell = item;
        }
        SpellDraggablePayload spellDraggablePayload = slot.GetComponent<SpellDraggablePayload>();
        if (spellDraggablePayload != null)
        {
            spellDraggablePayload.spell = item;
        }
    }
}
