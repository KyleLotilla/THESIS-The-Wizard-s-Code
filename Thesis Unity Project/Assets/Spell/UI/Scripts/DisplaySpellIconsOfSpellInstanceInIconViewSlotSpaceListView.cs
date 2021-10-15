using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.UI.Views;
using DLSU.WizardCode.UI.Slots;
using DLSU.WizardCode.Spells;

namespace DLSU.WizardCode.Spells.UI
{
    public class DisplaySpellIconsOfSpellInstanceInIconViewSlotSpaceListView : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnSlotWithDataCreated(GameObject slotObject, object data)
        {
            SpellInstance spellInstance = data as SpellInstance;
            if (spellInstance != null)
            {
                IconView iconViewOfSlotObject = slotObject.GetComponent<IconView>();
                if (iconViewOfSlotObject != null)
                {
                    iconViewOfSlotObject.Icon.sprite = spellInstance.Icon;
                }
            }
        }
    }

}
