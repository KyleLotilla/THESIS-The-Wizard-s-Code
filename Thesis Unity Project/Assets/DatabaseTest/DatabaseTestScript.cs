using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseTestScript : MonoBehaviour
{
    public MaterialDatabase materialDatabase;
    public MaterialInventory materialInventory;
    public SpellDatabase spellDatabase;
    public SpellInventory spellInventory;
    public SpellCodeInventory spellCodeInventory;

    // Start is called before the first frame update
    void Awake()
    {
        Spell fireBall = spellDatabase.GetSpell(2);
        spellInventory.EquipSpell(fireBall);

        Spell electro = spellDatabase.GetSpell(3);
        spellInventory.EquipSpell(electro);

        spellInventory.AddSpell(spellDatabase.GetSpell(4));
        spellInventory.AddSpell(spellDatabase.GetSpell(5));
        spellInventory.AddSpell(spellDatabase.GetSpell(2));

        SpellCode spellCode1 = new SpellCode();
        spellCode1.AddSpell(fireBall);
        spellCode1.AddSpell(fireBall);
        spellCode1.AddSpell(spellDatabase.GetSpell(0));
        spellCode1.name = "Test1";
        spellCodeInventory.AddSpellCode(spellCode1);

        SpellCode spellCode2 = new SpellCode();
        spellCode2.AddSpell(spellDatabase.GetSpell(1));
        spellCode2.AddSpell(fireBall);
        spellCode2.AddSpell(electro);
        spellCode2.name = "Test2";
        spellCodeInventory.EquipSpellCode(spellCode2);

        materialInventory.AddMaterial(materialDatabase.GetMaterial(0));
        materialInventory.AddMaterial(materialDatabase.GetMaterial(1));
        materialInventory.AddMaterial(materialDatabase.GetMaterial(1));
        materialInventory.AddMaterial(materialDatabase.GetMaterial(0));

        materialInventory.AddMaterial(materialDatabase.GetMaterial(2));
        materialInventory.AddMaterial(materialDatabase.GetMaterial(3));

        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
