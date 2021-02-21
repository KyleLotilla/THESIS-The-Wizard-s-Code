using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject container { get; set; }
    private Vector3 startPos;
    [SerializeField]
    private CanvasGroup canvasGroup;
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private bool _isDraggable = true;
    [SerializeField]
    public bool isDraggable
    {
        get
        {
            return _isDraggable;
        }
        set
        {
            _isDraggable = value;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isDraggable)
        {
            canvasGroup.blocksRaycasts = false;
            canvas.overrideSorting = true;
            startPos = this.transform.position;
        }
        else
        {
            eventData.pointerDrag = null;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        
        this.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvas.overrideSorting = false;
        this.transform.position = startPos;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
