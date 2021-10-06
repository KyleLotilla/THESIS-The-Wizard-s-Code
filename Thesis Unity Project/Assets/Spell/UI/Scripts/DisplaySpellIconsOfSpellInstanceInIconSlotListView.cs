using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.UI.ListViews;
using DLSU.WizardCode.UI.Slots;
using DLSU.WizardCode.Spells;

namespace DLSU.WizardCode.Spells.UI
{
    public class DisplaySpellIconsOfSpellInstanceInIconSlotListView : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnSlotWithDataCreated(GameObject slotObject, GameObject spaceObject, object item)
        {
            SpellInstance spellInstance = item as SpellInstance;
            if (spellInstance != null)
            {
                IconSlot iconSlot = slotObject.GetComponent<IconSlot>();
                if (iconSlot != null)
                {
                    iconSlot.Icon.sprite = spellInstance.Icon;
                }
            }
        }
    }

}
