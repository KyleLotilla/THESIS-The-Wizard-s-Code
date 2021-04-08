using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialInventoryMenu : ItemSlotMenu<Material>
{
    [SerializeField]
    private MaterialInventory materialInventory;
    // Start is called before the first frame update
    void Start()
    {
        items = materialInventory;
        RefreshMenu();
    }

    // Update is called once per frame
    void Update()
    {

    }

    override protected void OnSlotSpawn(GameObject slot, GameObject space, Material item)
    {
        MaterialSlot materialSlot = slot.GetComponent<MaterialSlot>();
        if (materialSlot != null)
        {
            materialSlot.material = item;
        }
        SlotSpace slotSpace = space.GetComponent<SlotSpace>();
        if (slotSpace != null)
        {
            slotSpace.slot = slot;
        }
    }
}
