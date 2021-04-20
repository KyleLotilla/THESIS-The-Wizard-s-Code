using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Spell Inventory")]
public class SpellInventory : ScriptableObject, IEnumerable<Spell>
{
    [SerializeField]
    private List<Spell> spells;
    [SerializeField]
    private List<Spell> _equipped;
    [SerializeField]
    private Dictionary<Guid, Spell> instanceDictionary;

    [SerializeField]
    public IEnumerable<Spell> equipped
    {
        get
        {
            return _equipped;
        }
    }
    [SerializeField]
    private int _maxEquipped;
    public int maxEquipped
    {
        get
        {
            return _maxEquipped;
        }
        set

        {
            _maxEquipped = value;
        }
    }
    public int Count
    {
        get
        {
            return spells.Count;
        }
    }

    public IEnumerable<Spell> fullInventory
    {
        get
        {
            List<Spell> fullInventory = new List<Spell>(spells.Count + _equipped.Count);
            fullInventory.AddRange(_equipped);
            fullInventory.AddRange(spells);
            return fullInventory;
        }
    }
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
            _equipped.Clear();
        }
        else
        {
            _equipped = new List<Spell>(maxEquipped);
        }

        if (instanceDictionary != null)
        {
            instanceDictionary.Clear();
        }
        else
        {
            instanceDictionary = new Dictionary<Guid, Spell>();
        }
    }

    public void AddSpell(Spell spell)
    {
        if (!instanceDictionary.ContainsKey(spell.instanceID))
        {
            spells.Add(spell);
            instanceDictionary[spell.instanceID] = spell;
        }
    }

    public Spell GetSpell(Guid instanceID)
    {
        if (instanceDictionary.ContainsKey(instanceID))
        {
            return instanceDictionary[instanceID];
        }
        else
        {
            return null;
        }
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
        if (_equipped.Count + 1 < maxEquipped)
        {
            if (!spell.isEquipped)
            {
                _equipped.Add(spell);
                spell.isEquipped = true;
                instanceDictionary[spell.instanceID] = spell;
            }
        }
    }

    public void UnequipSpell(Spell spell)
    {
        if (spell.isEquipped)
        {
            _equipped.Remove(spell);
            spell.isEquipped = false;
            instanceDictionary[spell.instanceID] = null;
        }
    }

    public void UnequipAll()
    {
        foreach (Spell spell in spells)
        {
            spell.isEquipped = false;
            instanceDictionary[spell.instanceID] = null;
        }
        spells.Clear();
    }

    public void RemoveSpell(Spell spell)
    {
        instanceDictionary[spell.instanceID] = null;
        spells.Remove(spell);
    }

    public IEnumerator GetEnumerator()
    {
        return ((IEnumerable)spells).GetEnumerator();
    }

    IEnumerator<Spell> IEnumerable<Spell>.GetEnumerator()
    {
        return ((IEnumerable<Spell>)spells).GetEnumerator();
    }
}
