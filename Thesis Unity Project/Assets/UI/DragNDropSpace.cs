using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DragNDropSpace : MonoBehaviour
{
    [SerializeField]
    private SlotSpace slotSpace;
    [SerializeField]
    private LayoutGroup layoutGroup;
    [SerializeField]
    private Draggable draggable;
    [SerializeField]
    private Droppable droppable;

    private Vector3 dragStartPos;
    private CanvasGroup slotCanvasGroup;
    private Canvas slotCanvas;
    private bool isDragging = false;

    void Awake()
    {
        if (draggable != null)
        {
            draggable.OnDragStart += OnDragStart;
            draggable.OnDragging += OnDragging;
            draggable.OnDragEnd += OnDragEnd;
        }

        if (droppable != null)
        {
            droppable.OnDropped += OnDropped;
        }

        if (slotSpace != null)
        {
            slotSpace.OnSlotChange += OnSlotChange;
            if (slotSpace.slot != null)
            {
                OnSlotChange(slotSpace.slot);
            }
        }
    }

    private void OnSlotChange(GameObject newSlot)
    {
        if (newSlot !=  null)
        {
            CanvasGroup canvasGroup = newSlot.GetComponent<CanvasGroup>();
            if (canvasGroup != null)
            {
                slotCanvasGroup = canvasGroup;
            }
            Canvas canvas = newSlot.GetComponent<Canvas>();
            if (canvas != null)
            {
                slotCanvas = canvas;
            }
        }
        else
        {
            slotCanvasGroup = null;
            slotCanvas = null;
        }
    }

    void Update()
    {
        
    }

    void OnDragStart(PointerEventData eventData)
    {
        if (!slotSpace.isEmpty)
        {
            isDragging = true;
            slotCanvas.overrideSorting = true;
            slotCanvas.sortingOrder = 1;
            slotCanvasGroup.blocksRaycasts = false;
            layoutGroup.enabled = false;
            dragStartPos = slotSpace.slot.transform.position;
        }
        else
        {
            eventData.pointerDrag = null;
        }
    }

    void OnDragging(PointerEventData eventData)
    {
        if (!slotSpace.isEmpty)
        {
            slotSpace.slot.transform.position = Input.mousePosition;
        }
    }

    void OnDragEnd(PointerEventData eventData)
    {
        StopDragging();
    }

    public void StopDragging()
    {
        if (isDragging)
        {
            slotCanvas.overrideSorting = false;
            slotCanvasGroup.blocksRaycasts = true;
            layoutGroup.enabled = true;
            isDragging = false;
        }

        if (!slotSpace.isEmpty)
        {
            slotSpace.slot.transform.position = dragStartPos;
        }
    }

    void OnDropped(PointerEventData eventData)
    {
        SlotSpace otherSpace = eventData.pointerDrag.GetComponent<SlotSpace>();
        DragNDropSpace otherDragNDropSpace = eventData.pointerDrag.GetComponent<DragNDropSpace>();
        if (otherSpace != null && otherDragNDropSpace != null)
        {
            otherDragNDropSpace.StopDragging();
            slotSpace.SwapSlots(otherSpace);
        }
    }

    
}
