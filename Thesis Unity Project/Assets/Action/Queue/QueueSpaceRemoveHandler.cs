using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueSpaceRemoveHandler : MonoBehaviour
{
    [SerializeField]
    private RemovableSlotSpace removableSlotSpace;
    [SerializeField]
    private QueueSpace queueSpace;

    // Start is called before the first frame update
    void Start()
    {
        removableSlotSpace.OnSlotRemove += OnSlotRemove;
    }

    private void OnSlotRemove(GameObject slot)
    {
        if (slot != null)
        {
            queueSpace.RemoveSlot();
            Destroy(slot);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
