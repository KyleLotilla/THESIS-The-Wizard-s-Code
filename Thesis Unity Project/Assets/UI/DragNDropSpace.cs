using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public delegate void OnSlotChange(GameObject newSlot);

public class DragNDropSpace : MonoBehaviour
{
    public event OnSlotChange OnSlotChange;

    private GameObject _slot;
    public GameObject slot
    {
        get
        {
            return _slot;
        }
        set
        {
            _slot = value;
            if (_slot != null)
            {
                _slot.transform.SetParent(this.transform, false);
                slotCanvas = _slot.GetComponent<Canvas>();
                slotCanvasGroup = _slot.GetComponent<CanvasGroup>();
            }
            OnSlotChange?.Invoke(_slot);
        }
    }

    [SerializeField]
    private GridLayoutGroup gridLayout;
    [SerializeField]
    private Draggable draggable;
    [SerializeField]
    private Droppable droppable;
    [SerializeField]
    private bool isSwappable = false;

    private Vector3 dragStartPos;
    private CanvasGroup slotCanvasGroup;
    private Canvas slotCanvas;
    private bool isDragging = false;

    void Start()
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDragStart(PointerEventData eventData)
    {
        isDragging = true;
        slotCanvas.overrideSorting = true;
        slotCanvas.sortingOrder = 1;
        slotCanvasGroup.blocksRaycasts = false;
        gridLayout.enabled = false;
        dragStartPos = slot.transform.position;
    }

    void OnDragging(PointerEventData eventData)
    {
        slot.transform.transform.position = Input.mousePosition;
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
            gridLayout.enabled = true;
            slot.transform.position = dragStartPos;
            isDragging = false;
        }
    }

    void OnDropped(PointerEventData eventData)
    {
        if (!(slot != null && !isSwappable))
        {
            DragNDropSpace otherSpace = eventData.pointerDrag.GetComponent<DragNDropSpace>();
            if (otherSpace != null)
            {
                otherSpace.StopDragging();
                SwapSlots(otherSpace);
            }
        }
    }

    void SwapSlots(DragNDropSpace otherSpace)
    {
        GameObject temp = slot;
        slot = otherSpace.slot;
        otherSpace.slot = temp;
    }
}
