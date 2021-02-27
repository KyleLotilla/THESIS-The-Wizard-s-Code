using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public delegate void OnContainerChange(GameObject newContainer);
public delegate void OnDragStart();
public delegate void OnDragEnd();

public class DragSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public event OnDragStart OnDragStart;
    public event OnDragEnd OnDragEnd;
    public event OnContainerChange OnContainerChange;
    private Vector3 startPos;
    [SerializeField]
    private CanvasGroup canvasGroup;
    [SerializeField]
    private Canvas canvas;
    private GameObject _container;
   
    [SerializeField]
    private bool _isDraggable = true;
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
            canvas.overrideSorting = true;
            canvas.sortingOrder = 1;
            canvasGroup.blocksRaycasts = false;
            this.startPos = this.gameObject.transform.position;
            OnDragStart?.Invoke();
        }
        else
        {
            eventData.pointerDrag = null;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.gameObject.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvas.overrideSorting = false;
        canvasGroup.blocksRaycasts = true;
        this.gameObject.transform.position = this.startPos;
        OnDragEnd?.Invoke();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NofityContainerChange(GameObject newContainer)
    {
        OnContainerChange?.Invoke(newContainer);
    }
}
