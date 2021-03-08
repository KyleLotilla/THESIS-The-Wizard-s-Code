using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public delegate void OnDragStart(PointerEventData eventData);
public delegate void OnDragging(PointerEventData eventData);
public delegate void OnDragEnd(PointerEventData eventData);

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public event OnDragStart OnDragStart;
    public event OnDragging OnDragging;
    public event OnDragEnd OnDragEnd;

    [SerializeField]
    private bool isDraggable = true;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isDraggable)
        {
            OnDragStart?.Invoke(eventData);
        }
        else
        {
            eventData.pointerDrag = null;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnDragging?.Invoke(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnDragEnd?.Invoke(eventData);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        OnDragStart = null;
        OnDragging = null;
        OnDragEnd = null;
    }
}
