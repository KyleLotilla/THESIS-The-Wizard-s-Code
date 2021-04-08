using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionDraggablePayload : MonoBehaviour
{
    [SerializeField]
    private ActionSlot actionSlot;
    [SerializeField]
    private DraggablePayload draggablePayload;

    // Start is called before the first frame update
    void Start()
    {
        draggablePayload.OnDraggablePayloadSpawn += OnDraggablePayloadSpawn;
    }

    private void OnDraggablePayloadSpawn(GameObject payload)
    {
        ActionSlot payloadActionSlot = payload.GetComponent<ActionSlot>();
        if (payloadActionSlot != null)
        {
            payloadActionSlot.action = actionSlot.action;
            payloadActionSlot.icon.sprite = actionSlot.icon.sprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
