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
        draggablePayload.OnVisualPayloadSpawn += OnVisualPayloadSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnVisualPayloadSpawn(GameObject payload)
    {
        SpellInventorySlot spellInventorySlot = payload.GetComponent<SpellInventorySlot>();
        if (spellInventorySlot != null)
        {
            spellInventorySlot.spell = spell;
        }
    }
}
