using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExecutionDropHandler : MonoBehaviour, IDropHandler
{
    public bool canDrop { get; set; }
    public bool occupied { get; set; }

    public void OnDrop(PointerEventData eventData)
    {
        if (canDrop)
        {
            eventData.pointerDrag.transform.SetParent(this.gameObject.transform);
            this.occupied = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.canDrop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (occupied)
        {
            this.canDrop = false;
        }
    }
}
