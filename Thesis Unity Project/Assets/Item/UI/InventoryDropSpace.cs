using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryDropSpace : DropSpace
{
    // Start is called before the first frame update
    void Start()
    {
        OnSlotDrop += ProcessDrop;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProcessDrop(PointerEventData eventData)
    {
        if (slot == null)
        {
            slot = eventData.pointerDrag;
        }
    }
}
