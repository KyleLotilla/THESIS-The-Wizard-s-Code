using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Spells;

public class SpellsInfoPanel : ItemSlotMenu<int>
{
    [SerializeField]
    private SpellDatabase spellDatabase;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowSpells(List<int> spellIDs)
    {
        items = spellIDs;
        RefreshMenu();
    }

    protected override void OnSlotSpawn(GameObject slot, GameObject space, int item)
    {
        /*
        Spell spell = spellDatabase.GetSpell(item);
        if (spell != null)
        {
            InfoIconPanel infoIconPanel = slot.GetComponent<InfoIconPanel>();
            if (infoIconPanel != null)
            {
                infoIconPanel.icon.sprite = spell.maleIcon;
                infoIconPanel.text.text = spell.spellName;
            }
        }
        */
    }
}
