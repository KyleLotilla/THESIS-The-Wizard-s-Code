using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public delegate void OnSlotFilled(GameObject slot);
public delegate void OnSlotMove();

public class InventorySlotSpace : MonoBehaviour, IDropHandler
{
    public event OnSlotFilled OnSlotFilled;
    public event OnSlotMove OnSlotMove;
    [SerializeField]
    public GameObject slot { get; private set; }
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

    public void OnDrop(PointerEventData eventData)
    {
        if (slot == null && isDroppable)
        {
            FillSlotSpace(eventData.pointerDrag);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FillSlotSpace(GameObject newSlot)
    {
        if (slot == null)
        {
            slot = newSlot;
            InventorySlot inventorySlot = slot.GetComponent<InventorySlot>();
            if (inventorySlot != null)
            {
                slot.transform.SetParent(this.transform);
                GameObject previousContainer = inventorySlot.container;
                if (previousContainer != null)
                {
                    InventorySlotSpace previousContainerSpace = previousContainer.GetComponent<InventorySlotSpace>();
                    if (previousContainerSpace != null)
                    {
                        previousContainerSpace.MoveSlotAway();
                    }
                }
                inventorySlot.container = this.gameObject;
                if (OnSlotFilled != null)
                {
                    OnSlotFilled.Invoke(slot);
                }
            }
        }

    }

    public void EmptySlotSpace()
    {
        slot = null;
        
    }

    public void MoveSlotAway()
    {
        EmptySlotSpace();
        if (OnSlotMove != null)
        {
            OnSlotMove.Invoke();
        }
    }
}
