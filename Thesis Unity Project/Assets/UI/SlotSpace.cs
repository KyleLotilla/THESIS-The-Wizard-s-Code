using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnSlotChange(GameObject newSlot);

public class SlotSpace : MonoBehaviour
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
            }
            OnSlotChange?.Invoke(_slot);
        }
    }

    public bool isEmpty
    {
        get
        {
            return _slot == null;
        }
    }

    [SerializeField]
    private bool _isSwappable = false;

    public bool isSwappable
    {
        get
        {
            return _isSwappable;
        }
        set
        {
            _isSwappable = value;
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

    public void SwapSlots(SlotSpace otherSpace)
    {
        if (slot == null || (isSwappable && otherSpace.isSwappable))
        {
            GameObject temp = slot;
            slot = otherSpace.slot;
            otherSpace.slot = temp;
        }

    }
}
