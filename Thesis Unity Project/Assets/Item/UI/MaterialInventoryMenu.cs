using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialInventoryMenu : MonoBehaviour
{
    [SerializeField]
    private MaterialInventory inventory;
    [SerializeField]
    private GameObject materialSlotPrefab;
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
        foreach (Material material in inventory)
        {
            GameObject spaceObject = Instantiate(spacePrefab, this.transform);
            GameObject slot = Instantiate(materialSlotPrefab, spaceObject.transform);
            MaterialInventorySlot materialSlot = slot.GetComponent<MaterialInventorySlot>();
            if (materialSlot != null)
            {
                materialSlot.material = material;
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
