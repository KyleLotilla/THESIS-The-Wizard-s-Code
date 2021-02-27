using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public delegate void OnSlotDrop(PointerEventData eventData);
public delegate void OnSlotFilled(GameObject slot);
public delegate void OnSlotEmpty();

public class DropSpace : MonoBehaviour, IDropHandler
{
    public event OnSlotDrop OnSlotDrop;
    public event OnSlotFilled OnSlotFilled;
    public event OnSlotEmpty OnSlotEmpty;
    public GameObject _slot;
    public GameObject slot
    {
        get
        {
            return _slot;
        }
        set
        {
            if (slot != null)
            {
                DragSlot dragSlot = slot.GetComponent<DragSlot>();
                if (dragSlot != null)
                {
                    dragSlot.OnContainerChange -= OnSlotContainerChange;
                    dragSlot.OnDragStart -= OnDragStart;
                    dragSlot.OnDragEnd -= OnDragEnd;
                    dragSlot.NofityContainerChange(null);
                }
            }
            _slot = value;
            if (_slot != null)
            {
                DragSlot dragSlot = value.GetComponent<DragSlot>();
                if (dragSlot != null)
                {
                    dragSlot.NofityContainerChange(null);
                    dragSlot.OnContainerChange += OnSlotContainerChange;
                    dragSlot.OnDragStart += OnDragStart;
                    dragSlot.OnDragEnd += OnDragEnd;
                }
                _slot.transform.SetParent(this.transform);
                OnSlotFilled?.Invoke(_slot);
            }
            else
            {
                OnSlotEmpty?.Invoke();
            }
        }

    }
    [SerializeField]
    private bool _isDroppable = true;
    public bool isDroppable
    {
        get
        {
            return _isDroppable;
        }
        set
        {
            _isDroppable = value;
        }
    }

    [SerializeField]
    private GridLayoutGroup gridLayout;
    public void OnDrop(PointerEventData eventData)
    {
        if (isDroppable)
        {
            OnSlotDrop?.Invoke(eventData);
        }
    }

    public void OnSlotContainerChange(GameObject newContainer)
    {
        if (newContainer != this.gameObject)
        {
            slot = null;
        }
    }

    public void OnDragStart()
    {
        gridLayout.enabled = false;
    }

    public void OnDragEnd()
    {
        gridLayout.enabled = true;
    }
}
