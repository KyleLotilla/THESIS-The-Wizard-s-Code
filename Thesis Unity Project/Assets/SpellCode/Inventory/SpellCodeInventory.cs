using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/SpellCode Inventory")]
public class SpellCodeInventory : ScriptableObject, IEnumerable<SpellCode>
{
    [SerializeField]
    private List<SpellCode> spellCodes;
    private List<SpellCode> _equipped;
    public IEnumerable<SpellCode> equipped
    {
        get
        {
            return _equipped;
        }
    }

    [SerializeField]
    private int _minSpells;
    public int minSpells
    {
        get
        {
            return _minSpells;
        }
        set
        {
            _minSpells = value;
        }
    }

    [SerializeField]
    private int _maxSpells;
    public int maxSpells
    {
        get
        {
            return _maxSpells;
        }
        set
        {
            _maxSpells = value;
        }
    }
    void OnEnable()
    {
        if (spellCodes != null)
        {
            spellCodes.Clear();
        }
        else
        {
            spellCodes = new List<SpellCode>();
        }

        if (_equipped != null)
        {
            _equipped.Clear();
        }
        else
        {
            _equipped = new List<SpellCode>();
        }
    }
    public void AddSpellCode(SpellCode spellCode)
    {
        spellCodes.Add(spellCode);
    }

    public void RemoveSpellCode(SpellCode spellCode)
    {
        if (spellCode.isEquipped)
        {
            _equipped.Remove(spellCode);
        }
        else
        {
            spellCodes.Remove(spellCode);
        }
    }

    public void RemoveSpellInstance(Spell spell)
    {
        for (int i = spellCodes.Count - 1; i >= 0; i--)
        {
            spellCodes[i].RemoveSpellInstance(spell);
            if (spellCodes[i].Count < minSpells)
            {
                spellCodes.Remove(spellCodes[i]);
            }
        }

        for (int i = _equipped.Count - 1; i >= 0; i--)
        {
            _equipped[i].RemoveSpellInstance(spell);
            if (_equipped[i].Count < minSpells)
            {
                _equipped.Remove(_equipped[i]);
            }
        }
    }

    public void EquipSpellCode(SpellCode spellCode)
    {
        spellCodes.Remove(spellCode);
        _equipped.Add(spellCode);
        spellCode.isEquipped = true;
    }

    public void UnequipSpellCode(SpellCode spellCode)
    {
        spellCode.isEquipped = false;
        _equipped.Remove(spellCode);
    }

    public void Clear()
    {
        spellCodes.Clear();
    }

    IEnumerator<SpellCode> IEnumerable<SpellCode>.GetEnumerator()
    {
        return ((IEnumerable<SpellCode>)spellCodes).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)spellCodes).GetEnumerator();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
