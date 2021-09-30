using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DLSU.WizardCode.UI.Slots;

public class SpellPayloadDropHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject spellCodeSlotPrefab;
    /*
    [SerializeField]
    private Droppable droppable;
    */
    [SerializeField]
    private SlotSpace space;
    // Start is called before the first frame update
    void Start()
    {
        //droppable.OnDropped += OnDropped;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDropped(PointerEventData eventData)
    {
        /*
        GameObject dropped = eventData.pointerDrag;
        SpellSlot spellSlot = dropped.GetComponent<SpellSlot>();
        SpellDraggablePayload spellDraggablePayload = dropped.GetComponent<SpellDraggablePayload>();
        
        if (spellSlot != null && spellDraggablePayload != null && space.slot == null)
        {
                GameObject spellCodeSlot = Instantiate(spellCodeSlotPrefab);
                if (spellCodeSlot != null)
                {
                    SpellSlot newSpellSlot = spellCodeSlot.GetComponent<SpellSlot>();
                    if (newSpellSlot != null)
                    {
                        newSpellSlot.spell = spellSlot.spell;
                        space.slot = spellCodeSlot;
                    }
                }
        }
        */
    }
 }

