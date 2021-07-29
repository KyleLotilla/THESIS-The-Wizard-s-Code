using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QueueSpaceHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    SlotSpace slotSpace;

    [SerializeField]
    private ExplorationHoverHandler explorationHoverHandler;
    // Start is called before the first frame update
    void Start()
    {
        slotSpace.OnSlotChange += OnSlotChange;
    }

    private void OnSlotChange(GameObject newSlot)
    {
        if (newSlot == null)
        {
            explorationHoverHandler.ClearCurrentHover();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!slotSpace.isEmpty)
        {
            explorationHoverHandler.HandleHover(slotSpace.slot);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        explorationHoverHandler.ClearCurrentHover();
    }
}
