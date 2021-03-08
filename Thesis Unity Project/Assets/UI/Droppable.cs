using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public delegate void OnDropped(PointerEventData eventData);

public class Droppable : MonoBehaviour, IDropHandler
{
    public event OnDropped OnDropped;
    [SerializeField]
    private bool isDroppable = true;

    public void OnDrop(PointerEventData eventData)
    {
        if (isDroppable)
        {
            OnDropped?.Invoke(eventData);
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

    private void OnDestroy()
    {
        OnDropped = null;
    }
}
