using UnityEngine;
using UnityEngine.UI;

public class SpellEquipmentSpace : MonoBehaviour
{
    [SerializeField]
    DragNDropSpace space;
    [SerializeField]
    private SpellInventory spellInventory;
    private Spell _spell;
    [SerializeField]
    public Spell spell
    {
        get
        {
            return _spell;
        }
        set
        {
            _spell = value;
        }
    }
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
        if (slot == null)
        {
            UnequipSpell();
        }
        else
        {
            SpellInventorySlot spellInventorySlot = slot.GetComponent<SpellInventorySlot>();
            if (spellInventorySlot != null)
            {
                EquipSpell(spellInventorySlot.spell);
            }
        }
    }

    void EquipSpell(Spell newSpell)
    {
        if (newSpell != null)
        {
            if (!newSpell.isEquipped)
            {
                if (spell != null)
                {
                    UnequipSpell();
                }
                spellInventory.RemoveSpell(newSpell);
                spellInventory.EquipSpell(newSpell);
                spell = newSpell;
                
                /*
                foreach (Spell spell in spellInventory.equipped)
                {
                    Debug.Log(spell.name);
                }
                */
            }
        }
    }

    void UnequipSpell()
    {
        spellInventory.UnequipSpell(spell);
        spellInventory.AddSpell(spell);
        this.spell = null;
    }
}
