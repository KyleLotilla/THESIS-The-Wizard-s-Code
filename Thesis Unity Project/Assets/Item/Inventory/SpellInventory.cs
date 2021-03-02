﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Spell Inventory")]
public class SpellInventory : ScriptableObject, IEnumerable
{
    [SerializeField]
    private List<Spell> spells;
    [SerializeField]
    public List<Spell> equipped { get; private set; }

    // Start is called before the first frame update
    void OnEnable()
    {
        if (spells != null)
        {
            spells.Clear();
        }
        else
        {
            spells = new List<Spell>();
        }

        if (equipped != null)
        {
            equipped.Clear();
        }
        else
        {
            equipped = new List<Spell>();
        }
    }

    public void AddSpell(Spell spell)
    {
        spells.Add(spell);
    }

    public Spell GetSpellAt(int index)
    {
        if (index < spells.Count && index > -1)
        {
            return spells[index];
        }
        else
        {
            return null;
        }
    }

    public void EquipSpell(Spell spell)
    {
        if (!spell.isEquipped)
        {
            equipped.Add(spell);
            spell.isEquipped = true;
        }
    }

    public void UnequipItem(Spell spell)
    {
        if (spell.isEquipped)
        {
            equipped.Remove(spell);
            spell.isEquipped = false;
        }
    }

    public void UnequipAll()
    {
        foreach (Spell spell in spells)
        {
            spell.isEquipped = false;
        }
        spells.Clear();
    }

    public void RemoveSpell(Spell spell)
    {
        spells.Remove(spell);
    }

    public List<GameObject> GetEquippedActionSlots()
    {
        List<GameObject> spellActions = new List<GameObject>();
        foreach (Spell spell in equipped)
        {
            Action action = Resources.Load<Action>(spell.pathToActionSlot);
            if (action != null)
            {
                action.spell = spell;
                spellActions.Add(action.gameObject);
            }
        }
        return spellActions;
    }

    public IEnumerator GetEnumerator()
    {
        return ((IEnumerable)spells).GetEnumerator();
    }
}