using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public delegate void OnVisualPayloadSpawn(GameObject visualPayload);

public class DraggablePayload : MonoBehaviour
{
    public event OnVisualPayloadSpawn OnVisualPayloadSpawn;

    [SerializeField]
    private Draggable dragabble;
    [SerializeField]
    private GameObject visualPayloadPrefab;
    private GameObject currentVisualPayload;

    // Start is called before the first frame update
    void Start()
    {
        dragabble.OnDragStart += OnDragStart;
        dragabble.OnDragging += OnDragging;
        dragabble.OnDragEnd += OnDragEnd;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDragStart(PointerEventData eventData)
    {
        currentVisualPayload = Instantiate(visualPayloadPrefab, Input.mousePosition, Quaternion.identity, this.transform);
        if (currentVisualPayload != null)
        {
            OnVisualPayloadSpawn?.Invoke(currentVisualPayload);
        }
    }

    void OnDragging(PointerEventData eventData)
    {
        currentVisualPayload.transform.position = Input.mousePosition;
    }

    void OnDragEnd(PointerEventData eventData)
    {
        DestroyImmediate(currentVisualPayload);
    }
}
