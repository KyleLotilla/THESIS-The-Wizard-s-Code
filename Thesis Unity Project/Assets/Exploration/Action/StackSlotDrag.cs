using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StackSlotDrag : MonoBehaviour
{
    [SerializeField]
    private Draggable dragabble;
    [SerializeField]
    private GameObject visualPayloadPrefab;
    [SerializeField]
    private ActionSlot actionSlot;

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
        currentVisualPayload = Instantiate(visualPayloadPrefab, this.transform.parent);
        if (currentVisualPayload != null)
        {
            StackVisualPayload visualPayload = currentVisualPayload.GetComponent<StackVisualPayload>();
            if (visualPayload != null)
            {
                visualPayload.image.sprite = actionSlot.spell.icon;
                currentVisualPayload.transform.position = Input.mousePosition;
            }
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
