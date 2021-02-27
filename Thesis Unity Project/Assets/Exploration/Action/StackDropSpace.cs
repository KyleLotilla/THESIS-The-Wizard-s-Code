using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StackDropSpace : DropSpace
{
    // Start is called before the first frame update
    void Start()
    {
        this.OnSlotDrop += ProcessDrop;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ProcessDrop(PointerEventData eventData)
    {
        GameObject gameObject = eventData.pointerDrag;
        ActionSlot actionSlot = gameObject.GetComponent<ActionSlot>();
        ActionSlot currentActionSlot = slot.GetComponent<ActionSlot>();
        if (actionSlot != null && currentActionSlot != null)
        {
            if (actionSlot.isInQueue && actionSlot.slotID == currentActionSlot.slotID)
            {
                currentActionSlot.EnableSlot();
                actionSlot.OnEndDrag(null);
                actionSlot.NofityContainerChange(null);
                DestroyImmediate(gameObject);
            }
        }
    }
}
