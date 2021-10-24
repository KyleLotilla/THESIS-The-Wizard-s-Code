using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.ScriptableObjectVariables;

namespace DLSU.WizardCode.SpellCodes.Exploration
{
    public class SetSpellCodeToSpellCodeOfCurrentHoveredActionObject : MonoBehaviour
    {
        [SerializeField]
        private SpellCodeHolder spellCodeHolder;
        [SerializeField]
        private GameObjectVariable currentHoveredActionObject;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnActionObjectHoverEnter()
        {
            if (currentHoveredActionObject.Value != null)
            {
                SpellCodeHolder spellCodeHolderOfCurrentHoveredActionObject = currentHoveredActionObject.Value.GetComponent<SpellCodeHolder>();
                if (spellCodeHolderOfCurrentHoveredActionObject != null)
                {
                    spellCodeHolder.SpellCode = spellCodeHolderOfCurrentHoveredActionObject.SpellCode;
                }
            }
        }
    }

}
