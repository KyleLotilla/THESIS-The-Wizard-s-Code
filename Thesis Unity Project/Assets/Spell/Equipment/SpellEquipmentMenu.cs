using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Spells;
using DLSU.WizardCode.UI.DragNDrop;

public class SpellEquipmentMenu : ItemSlotMenu<Spell>
{
    [SerializeField]
    private SpellInventory spellInventory;
    [SerializeField]
    private bool isTutorial = false;
    // Start is called before the first frame update
    void Start()
    {
        /*
        items = spellInventory.EquippedSpells;
        maxSpaces = spellInventory.MaxEquipped;
        RefreshMenu();
        */
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
        if (space != null)
        {
            /*
            SlotSpace slotSpace = space.GetComponent<SlotSpace>();
            if (slotSpace != null)
            {
                slotSpace.slot = slot;
            }
            */
            if (isTutorial)
            {
                Draggable draggable = space.GetComponent<Draggable>();
                if (draggable != null)
                {
                    draggable.IsDraggable = false;
                }
            }
        }
    }

    protected override void OnEmptySpaceSpawn(GameObject space)
    {
        if (space != null)
        {
            if (isTutorial)
            {
                Draggable draggable = space.GetComponent<Draggable>();
                if (draggable != null)
                {
                    draggable.IsDraggable = false;
                }
            }
        }
    }
}
