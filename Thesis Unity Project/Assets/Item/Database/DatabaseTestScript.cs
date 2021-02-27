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
        materialInventory.AddMaterial(materialDatabase.GetMaterial(0));
        materialInventory.AddMaterial(materialDatabase.GetMaterial(1));
        materialInventory.AddMaterial(materialDatabase.GetMaterial(0));
        Spell fireBall = spellDatabase.GetSpell(0);
        spellInventory.EquipSpell(fireBall);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
