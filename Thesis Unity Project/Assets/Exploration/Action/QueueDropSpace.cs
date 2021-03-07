using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class QueueDropSpace : DropSpace
{
    public ActionSlot stackActionSlot;
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
                QueueDropSpace otherDropSpace = gameObject.transform.parent.gameObject.GetComponent<QueueDropSpace>();
                if (otherDropSpace != null)
                {
                    SwapQueueSlot(otherDropSpace);
                }
            }
            else
            {
                if (slot == null)
                {
                    CreateQueueSlot(actionSlot);
                }
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
                stackActionSlot = actionSlot;
                BoxCollider2D collider = newSlot.GetComponent<BoxCollider2D>();
                Rigidbody2D rigidbody = newSlot.GetComponent<Rigidbody2D>();
                if (collider != null)
                {
                    Destroy(collider);
                }
                if (rigidbody != null)
                {
                    Destroy(rigidbody);
                }

                actionSlot.DisableSlot();
            }
        }
    }

    void SwapQueueSlot(QueueDropSpace otherDropSpace)
    {
        if (otherDropSpace != null)
        {
            GameObject tempSlot = slot;
            slot = otherDropSpace.slot;
            otherDropSpace.slot = tempSlot;

            ActionSlot tempStackActionSlot = stackActionSlot;
            stackActionSlot = otherDropSpace.stackActionSlot;
            otherDropSpace.stackActionSlot = tempStackActionSlot;
        }
    }

    public void RemoveSlot()
    {
        stackActionSlot.EnableSlot();
        DestroyImmediate(slot);
        slot = null;
        stackActionSlot = null;
    }

    public void ConsumeSlot()
    {
        stackActionSlot.EnableSlot();
        DestroyImmediate(slot);
        DestroyImmediate(stackActionSlot.gameObject);
        slot = null;
        stackActionSlot = null;
    }
}
