using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCode : IEnumerable<Spell>
{
    public string name { get; set; }
    private List<Spell> spells = new List<Spell>();
    public int Count
    {
        get
        {
            return spells.Count;
        }
    }
    public bool isEquipped { get; set; }
    public Sprite actionIcon { get; set; }

    public Spell this[int i]
    {
        get
        {
            return spells[i];
        }
    }
    public int AddSpell(Spell spell)
    {
        spells.Add(spell);
        return spells.Count - 1;
    }

    public void RemoveSpellInstance(Spell spell)
    {
        spells.RemoveAll(x => x == spell);
    }

    public void RemoveSpellAt(int index)
    {
        if (index >= 0 && index < spells.Count)
        {
            spells[index] = null;
        }
    }

    public void ClearSpells()
    {
        spells.Clear();
    }

    public IEnumerator<Spell> GetEnumerator()
    {
        return ((IEnumerable<Spell>)spells).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)spells).GetEnumerator();
    }
}
