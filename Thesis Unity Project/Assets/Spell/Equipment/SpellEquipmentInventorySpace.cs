using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellEquipmentInventorySpace : MonoBehaviour
{
    [SerializeField]
    SlotSpace space;
    [SerializeField]
    private SpellInventory spellInventory;

    // Start is called before the first frame update
    void Start()
    {
        space.OnSlotChange += OnSlotChange;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnSlotChange(GameObject slot)
    {
        if (slot != null)
        {
            SpellSlot spellSlot = slot.GetComponent<SpellSlot>();
            if (spellSlot != null)
            {
                Spell spell = spellSlot.spell;
                if (spell.isEquipped)
                {
                    UnequipSpell(spell);
                }
            }
        }
    }

    void UnequipSpell(Spell spell)
    {
        if (spell != null)
        {
            spellInventory.UnequipSpell(spell);
            spellInventory.AddSpell(spell);
            /*
            foreach (Spell spell1 in spellInventory.equipped)
            {
                Debug.Log(spell1.name);
            }
            */
        }
    }
}
