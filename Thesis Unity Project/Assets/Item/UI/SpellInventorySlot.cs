using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellInventorySlot : DragSlot
{
    private Spell _spell;
    [SerializeField]
    private Image iconUI;
    [SerializeField]
    public Spell spell
    {
        get
        {
            return _spell;
        }
        set
        {
            _spell = value;
            iconUI.sprite = _spell.icon;
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
}
