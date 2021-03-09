using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellInventoryMenu : MonoBehaviour
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
        RefreshInventory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshInventory()
    {
        RemoveAllSlots();
        foreach (Spell spell in inventory)
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
