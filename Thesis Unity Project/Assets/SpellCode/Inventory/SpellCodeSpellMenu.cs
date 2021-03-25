using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [SerializeField]
    private List<DragNDropSpace> _spaces;
    public IEnumerable<DragNDropSpace> spaces
    {
        get
        {
            return _spaces;
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
        SpellInventorySlot spellInventorySlot = slot.GetComponent<SpellInventorySlot>();
        if (spellInventorySlot != null)
        {
            spellInventorySlot.spell = item;
        }
        DragNDropSpace dragNDropSpace = space.GetComponent<DragNDropSpace>();
        if (dragNDropSpace != null)
        {
            dragNDropSpace.slot = slot;
            _spaces.Add(dragNDropSpace);
        }
    }

    protected override void OnEmptySpaceSpawn(GameObject space)
    {
        DragNDropSpace dragNDropSpace = space.GetComponent<DragNDropSpace>();
        if (dragNDropSpace != null)
        {
            _spaces.Add(dragNDropSpace);
        }
    }
}
