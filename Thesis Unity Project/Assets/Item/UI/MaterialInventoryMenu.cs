using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialInventoryMenu : MonoBehaviour
{
    [SerializeField]
    private MaterialInventory inventory;
    [SerializeField]
    private GameObject slotTemplate;
    [SerializeField]
    private GameObject slotSpaceTemplate;
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
        foreach (Material material in inventory)
        {
            GameObject slotSpaceObject = Instantiate(slotSpaceTemplate, this.transform);
            GameObject slot = Instantiate(slotTemplate, slotSpaceObject.transform);
            MaterialSlot materialSlot = slot.GetComponent<MaterialSlot>();
            if (materialSlot != null)
            {
                materialSlot.material = material;
            }
            InventorySlotSpace inventorySlotSpace = slotSpaceObject.GetComponent<InventorySlotSpace>();
            if (inventorySlotSpace != null)
            {
                inventorySlotSpace.FillSlotSpace(slot);
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
