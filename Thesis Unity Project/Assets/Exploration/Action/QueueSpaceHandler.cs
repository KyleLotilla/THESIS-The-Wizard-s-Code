using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QueueSpaceHandler : MonoBehaviour
{
    [SerializeField]
    private DragNDropSpace space;
    [SerializeField]
    private Droppable droppable;
    [SerializeField]
    private GameObject queueSlotPrefab;
    // Start is called before the first frame update
    void Start()
    {
        droppable.OnDropped += OnDropped;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDropped(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        ActionSlot droppedActionSlot = dropped.GetComponent<ActionSlot>();
        if (droppedActionSlot != null)
        {
            if (!droppedActionSlot.isInQueue && space.slot == null)
            {
                GameObject queueSlot = Instantiate(queueSlotPrefab);
                if (queueSlot != null)
                {
                    ActionSlot queueActionSlot = queueSlot.GetComponent<ActionSlot>();
                    if (queueActionSlot != null)
                    {
                        queueActionSlot.spell = droppedActionSlot.spell;
                        queueActionSlot.action = droppedActionSlot.action;
                        queueActionSlot.isInQueue = true;
                        droppedActionSlot.DisableSlot();
                        space.slot = queueSlot;
                    }
                    QueueSlot queueToStackSlotHandler = queueSlot.GetComponent<QueueSlot>();
                    if (queueToStackSlotHandler != null)
                    {
                        queueToStackSlotHandler.stackSlot = droppedActionSlot;
                    }
                }
            }
        }
    }

    public bool isFilled()
    {
        if (space.slot != null)
        {
            return true;
        }
        return false;
    }

    public ActionSlot GetActionSlot()
    {
        if (isFilled())
        {
            return space.slot.GetComponent<ActionSlot>();
        }
        else
        {
            return null;
        }
    }

    public void RemoveSlot()
    {
        QueueSlot queueToStackSlotHandler = space.slot.GetComponent<QueueSlot>();
        if (queueToStackSlotHandler != null)
        {
            queueToStackSlotHandler.stackSlot.EnableSlot();
        }
        DestroyImmediate(space.slot);
        space.slot = null;
    }

    public void ConsumeSlot()
    {
        QueueSlot queueToStackSlotHandler = space.slot.GetComponent<QueueSlot>();
        if (queueToStackSlotHandler != null)
        {
            DestroyImmediate(queueToStackSlotHandler.stackSlot.gameObject);
        }
        DestroyImmediate(space.slot);
        space.slot = null;
    }
}
