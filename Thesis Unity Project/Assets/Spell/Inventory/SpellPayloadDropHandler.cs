using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpellPayloadDropHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject spellCodeSlotPrefab;
    [SerializeField]
    private Droppable droppable;
    [SerializeField]
    private DragNDropSpace space;
    // Start is called before the first frame update
    void Start()
    {
        droppable.OnDropped += OnDropped;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDropped(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        SpellInventorySlot spellInventorySlot = dropped.GetComponent<SpellInventorySlot>();
        SpellDraggablePayload spellDraggablePayload = dropped.GetComponent<SpellDraggablePayload>();
        if (spellInventorySlot != null && spellDraggablePayload != null && space.slot == null)
        {
                GameObject spellCodeSlot = Instantiate(spellCodeSlotPrefab);
                if (spellCodeSlot != null)
                {
                    SpellInventorySlot newSpellInventorySlot = spellCodeSlot.GetComponent<SpellInventorySlot>();
                    if (newSpellInventorySlot != null)
                    {
                        newSpellInventorySlot.spell = spellInventorySlot.spell;
                        space.slot = spellCodeSlot;
                    }
                }
        }
    }
 }

