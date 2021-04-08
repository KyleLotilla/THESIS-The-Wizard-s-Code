using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnSlotRemove(GameObject slot);

public class RemovableSlotSpace : MonoBehaviour
{
    public event OnSlotRemove OnSlotRemove;

    [SerializeField]
    private SlotSpace space;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {   
    }

    public void RemoveSlot()
    {
        if (!space.isEmpty)
        {
            OnSlotRemove?.Invoke(space.slot);
            space.slot = null;
        }
    }
}
