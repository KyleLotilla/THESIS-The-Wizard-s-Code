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
    private GameObject dropSpaceTemplate;
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
            GameObject dropSpace = Instantiate(dropSpaceTemplate, this.transform);
            GameObject slot = Instantiate(slotTemplate, dropSpace.transform);
            MaterialInventorySlot materialSlot = slot.GetComponent<MaterialInventorySlot>();
            if (materialSlot != null)
            {
                materialSlot.material = material;
            }
            InventoryDropSpace inventoryDropSpace = dropSpace.GetComponent<InventoryDropSpace>();
            if (inventoryDropSpace != null)
            {
                inventoryDropSpace.slot = slot;
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
