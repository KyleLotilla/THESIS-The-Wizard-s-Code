using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDraggablePayload : MonoBehaviour
{
    [SerializeField]
    private DraggablePayload draggablePayload;
    public Spell spell { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        draggablePayload.OnDraggablePayloadSpawn += OnDraggablePayloadSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDraggablePayloadSpawn(GameObject payload)
    {
        SpellSlot spellSlot = payload.GetComponent<SpellSlot>();
        if (spellSlot != null)
        {
            spellSlot.spell = spell;
        }
    }
}
