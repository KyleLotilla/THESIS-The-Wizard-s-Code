using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public delegate void OnDraggablePayloadSpawn(GameObject payload);

public class DraggablePayload : MonoBehaviour
{
    public event OnDraggablePayloadSpawn OnDraggablePayloadSpawn;

    [SerializeField]
    private Draggable draggable;
    [SerializeField]
    private GameObject payload;
    private GameObject visualPayload;

    // Start is called before the first frame update
    void Start()
    {
        draggable.OnDragStart += OnDragStart;
        draggable.OnDragging += OnDragging;
        draggable.OnDragEnd += OnDragEnd;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDragStart(PointerEventData eventData)
    {
        visualPayload = Instantiate(payload, Input.mousePosition, Quaternion.identity, this.transform);
        if (visualPayload != null)
        {
            OnDraggablePayloadSpawn?.Invoke(visualPayload);
        }
    }

    void OnDragging(PointerEventData eventData)
    {
        visualPayload.transform.position = Input.mousePosition;
    }

    void OnDragEnd(PointerEventData eventData)
    {
        DestroyImmediate(visualPayload);
    }
}
