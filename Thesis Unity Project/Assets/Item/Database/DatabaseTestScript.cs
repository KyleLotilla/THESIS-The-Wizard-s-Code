using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseTestScript : MonoBehaviour
{
    public MaterialDatabase materialDatabase;
    public MaterialInventory materialInventory;
    public SpellDatabase spellDatabase;
    public SpellInventory spellInventory;

    // Start is called before the first frame update
    void Awake()
    {
        Spell fireBall = spellDatabase.GetSpell(2);
        spellInventory.EquipSpell(fireBall);

        Spell electro = spellDatabase.GetSpell(3);
        spellInventory.EquipSpell(electro);


        /*
        spellInventory.AddSpell(spellDatabase.GetSpell(4));

        materialInventory.AddMaterial(materialDatabase.GetMaterial(0));
        materialInventory.AddMaterial(materialDatabase.GetMaterial(1));
        materialInventory.AddMaterial(materialDatabase.GetMaterial(1));
        materialInventory.AddMaterial(materialDatabase.GetMaterial(0));

        materialInventory.AddMaterial(materialDatabase.GetMaterial(2));
        materialInventory.AddMaterial(materialDatabase.GetMaterial(3));

        */
    }

    // Update is called once per frame
    void Update()
    {
    }
}
