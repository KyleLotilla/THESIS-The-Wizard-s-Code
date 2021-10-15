using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DLSU.WizardCode.SpellCodes.UI
{
    public class DisplaySpellCodeNameToText : MonoBehaviour
    {
        [SerializeField]
        private Text nameText;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnSpellCodeChanged(SpellCode spellCode)
        {
            nameText.text = spellCode.Name;
        }

        public void OnNoSpellCodeSet()
        {
            nameText.text = "";
        }
    }

}
