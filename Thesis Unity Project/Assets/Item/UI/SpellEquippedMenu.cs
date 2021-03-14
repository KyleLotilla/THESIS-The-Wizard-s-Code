using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellEquippedMenu : MonoBehaviour
{
    [SerializeField]
    private SpellInventory inventory;
    [SerializeField]
    private GameObject spellSlotPrefab;
    [SerializeField]
    private GameObject spacePrefab;
    // Start is called before the first frame update
    void Start()
    {
        RefreshEquipped();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RefreshEquipped()
    {
        RemoveAllSlots();
        foreach (Spell spell in inventory.equipped)
        {
            GameObject spaceObject = Instantiate(spacePrefab, this.transform);
            GameObject slot = Instantiate(spellSlotPrefab, spaceObject.transform);
            SpellInventorySlot spellSlot = slot.GetComponent<SpellInventorySlot>();
            if (spellSlot != null)
            {
                spellSlot.spell = spell;
            }
            DragNDropSpace space = spaceObject.GetComponent<DragNDropSpace>();
            if (space != null)
            {
                space.slot = slot;
            }
            SpellEquipmentSpace spellEquipmentSpace = spaceObject.GetComponent<SpellEquipmentSpace>();
            if (spellEquipmentSpace != null)
            {
                spellEquipmentSpace.spell = spell;
            }
        }


        int remainingSpacesNum = inventory.maxEquipped - inventory.equipped.Count;
        for (int i = 0; i < remainingSpacesNum; i++)
        {
            GameObject spaceObject = Instantiate(spacePrefab, this.transform);
        }
    }

    void RemoveAllSlots()
    {
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
