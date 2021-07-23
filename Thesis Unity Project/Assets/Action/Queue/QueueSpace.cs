using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QueueSpace : MonoBehaviour
{
    [SerializeField]
    private SlotSpace space;
    [SerializeField]
    private Droppable droppable;
    [SerializeField]
    private GameObject queueSlotPrefab;

    private DestroyHandler stackSlotDestroyHandler;
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
                GameObject queueSlotObject = Instantiate(queueSlotPrefab);
                if (queueSlotObject != null)
                {
                    ActionSlot queueActionSlot = queueSlotObject.GetComponent<ActionSlot>();
                    if (queueActionSlot != null)
                    {
                        queueActionSlot.icon.sprite = droppedActionSlot.icon.sprite;
                        queueActionSlot.action = droppedActionSlot.action;
                        queueActionSlot.isInQueue = true;
                        droppedActionSlot.DisableSlot();
                        space.slot = queueSlotObject;
                    }
                    QueueSlot queueSlot = queueSlotObject.GetComponent<QueueSlot>();
                    if (queueSlot != null)
                    {
                        queueSlot.stackSlot = droppedActionSlot;
                    }
                    DestroyHandler destroyHandler = droppedActionSlot.GetComponent<DestroyHandler>();
                    if (destroyHandler != null)
                    {
                        destroyHandler.OnGameObjectDestroy += OnStackSlotDestroy;
                        stackSlotDestroyHandler = destroyHandler;
                    }
                }
            }
        }
    }

    private void OnStackSlotDestroy()
    {
        DestroyImmediate(space.slot);
        space.slot = null;
        stackSlotDestroyHandler = null;
    }

    public void RemoveSlot()
    {
        QueueSlot queueSlot = space.slot.GetComponent<QueueSlot>();
        if (stackSlotDestroyHandler != null)
        {
            stackSlotDestroyHandler.OnGameObjectDestroy -= OnStackSlotDestroy;
        }
        if (queueSlot != null)
        {
            queueSlot.stackSlot.EnableSlot();
        }
        DestroyImmediate(space.slot);
        space.slot = null;
    }

    public void ConsumeSlot()
    {
        QueueSlot queueSlot = space.slot.GetComponent<QueueSlot>();
        if (stackSlotDestroyHandler != null)
        {
            stackSlotDestroyHandler.OnGameObjectDestroy -= OnStackSlotDestroy;
        }
        if (queueSlot != null)
        {
            DestroyImmediate(queueSlot.stackSlot.gameObject);
        }
        DestroyImmediate(space.slot);
        space.slot = null;
    }
}
