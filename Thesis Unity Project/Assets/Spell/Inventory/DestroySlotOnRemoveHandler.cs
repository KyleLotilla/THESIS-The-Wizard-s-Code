using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySlotOnRemoveHandler : MonoBehaviour
{
    [SerializeField]
    private RemovableSlotSpace removableSlotSpace;

    // Start is called before the first frame update
    void Start()
    {
        removableSlotSpace.OnSlotRemove += OnSlotRemove;
    }

    private void OnSlotRemove(GameObject slot)
    {
        if (slot != null)
        {
            Destroy(slot);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
