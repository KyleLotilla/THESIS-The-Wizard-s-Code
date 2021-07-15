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
    private bool canAddMoveLeft;
    [SerializeField]
    private bool isTutorial = false;
    // Start is called before the first frame update
    void Start()
    {
        RefreshMenu();
    }

    public override void RefreshMenu()
    {
        if (!isTutorial)
        {
            List<Spell> spells = spellInventory.fullInventory.ToList();
            if (canAddMoveLeft)
            {
                Spell moveLeftSpell = spellDatabase.GetMoveLeft();
                if (moveLeftSpell != null)
                {
                    spells.Insert(0, moveLeftSpell);
                }
            }
            Spell moveRightSpell = spellDatabase.GetMoveRight();
            if (moveRightSpell != null)
            {
                spells.Insert(1, moveRightSpell);
            }
            items = spells;
        }
        else
        {
            List<Spell> spells = new List<Spell>();
            Spell moveRightSpell = spellDatabase.GetMoveRight();
            if (moveRightSpell != null)
            {
                spells.Add(moveRightSpell);
            }
            Spell fireballSpell = spellInventory.equipped.First();
            if (fireballSpell != null)
            {
                spells.Add(fireballSpell);
            }
            items = spells;
        }
        base.RefreshMenu();
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
