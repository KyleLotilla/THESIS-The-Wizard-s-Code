using UnityEngine;
using UnityEngine.UI;

public class SpellEquipmentSpace : MonoBehaviour
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
                if (!spell.isEquipped)
                {
                    EquipSpell(spell);
                }
            }
        }
    }

    void EquipSpell(Spell spell)
    {
        if (spell != null)
        {
            if (!spell.isEquipped)
            {
                spellInventory.RemoveSpell(spell);
                spellInventory.EquipSpell(spell);
                /*
                foreach (Spell spell1 in spellInventory.equipped)
                {
                    Debug.Log(spell1.name);
                }
                */
            }
        }
    }
}
