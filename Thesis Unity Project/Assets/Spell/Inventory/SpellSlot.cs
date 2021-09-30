using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DLSU.WizardCode.Spells;

public class SpellSlot : MonoBehaviour
{
    private Spell _spell;
    [SerializeField]
    private Image icon;
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
            if (icon != null)
            {
                icon.sprite = _spell.MaleIcon;
            }
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
