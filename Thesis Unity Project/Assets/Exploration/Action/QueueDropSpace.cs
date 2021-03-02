using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class QueueDropSpace : DropSpace
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

    void ProcessDrop(PointerEventData eventData)
    {
        GameObject gameObject = eventData.pointerDrag;
        ActionSlot actionSlot = gameObject.GetComponent<ActionSlot>();
        if (actionSlot != null)
        {
            actionSlot.OnEndDrag(null);
            if (actionSlot.isInQueue)
            {
                if (slot != null)
                {
                    QueueDropSpace otherDropSpace = gameObject.transform.parent.gameObject.GetComponent<QueueDropSpace>();
                    if (otherDropSpace != null)
                    {
                        GameObject tempSlot = slot;
                        slot = gameObject;
                        otherDropSpace.slot = tempSlot;
                    }
                }
                else
                {
                    slot = gameObject;
                }
            }
            else
            {
                if (slot != null)
                {
                    ActionSlot currentActionSlot = slot.GetComponent<ActionSlot>();
                    if (currentActionSlot != null)
                    {
                        currentActionSlot.EnableSlot();
                        DestroyImmediate(slot);
                    }
                }
                CreateQueueSlot(actionSlot);
            }
        }
    }

    private void OnDestroy()
    {
        OnSlotDrop -= ProcessDrop;
    }

    void CreateQueueSlot(ActionSlot actionSlot)
    {
        GameObject newSlot = Instantiate(actionSlot.gameObject);
        if (newSlot != null)
        {
            ActionSlot newActionSlot = newSlot.GetComponent<ActionSlot>();
            if (newActionSlot != null)
            {
                slot = newSlot;
                newActionSlot.isInQueue = true;
                actionSlot.DisableSlot();
            }
        }
    }
}
