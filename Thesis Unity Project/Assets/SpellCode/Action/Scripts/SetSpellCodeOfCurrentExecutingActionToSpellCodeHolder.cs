using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.ScriptableObjectVariables;

namespace DLSU.WizardCode.SpellCodes.Actions
{
    public class SetSpellCodeOfCurrentExecutingActionToSpellCodeHolder : MonoBehaviour
    {
        [SerializeField]
        private GameObjectVariable currentExecutingActionObject;
        [SerializeField]
        private SpellCodeHolder spellCodeHolder;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetSpellCode()
        {
            SpellCodeHolder spellCodeHolderOfCurrentExecutingAction = currentExecutingActionObject.Value.GetComponent<SpellCodeHolder>();
            if (spellCodeHolderOfCurrentExecutingAction != null)
            {
                spellCodeHolder.SpellCode = spellCodeHolderOfCurrentExecutingAction.SpellCode;
            }
        }
    }

}
