using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Actions;
using DLSU.WizardCode.ScriptableObjectVariables;

namespace DLSU.WizardCode.SpellCodes.Actions
{
    public class SpellCodeAction : Action
    {
        [SerializeField]
        private GameObjectVariable spellCodeActionSequenceObject;
        [SerializeField]
        private List<Action> spellActions;
        public List<Action> SpellActions
        {
            get
            {
                return spellActions;
            }
            set
            {
                spellActions = value;
            }
        }
        [SerializeField]
        private SpellCodeHolder spellCodeHolder;
        protected override bool StartExecution()
        {
            Debug.Assert(spellCodeActionSequenceObject.Value != null, name + "Spell Code Action Sequence Object not set");
            if (spellCodeActionSequenceObject.Value != null)
            {
                SpellCodeHolder spellCodeHolderOfActionSequence = spellCodeActionSequenceObject.Value.GetComponent<SpellCodeHolder>();
                if (spellCodeHolderOfActionSequence != null)
                {
                    spellCodeHolderOfActionSequence.SpellCode = spellCodeHolder.SpellCode;
                }
                ActionSequence spellCodeActionSequence = spellCodeActionSequenceObject.Value.GetComponent<ActionSequence>();
                Debug.Assert(spellCodeActionSequence != null, name + "Spell Action Sequence Object has no Action Sequence");
                if (spellCodeActionSequence != null)
                {
                    spellCodeActionSequence.StartExecution(spellActions);
                    return true;
                }
            }
            return false;
        }

        void Start()
        {
        }

        void Update()
        {

        }

        public override void EndExecution()
        {
            if (IsExecuting)
            {
                ActionSequence spellCodeActionSequence = spellCodeActionSequenceObject.Value.GetComponent<ActionSequence>();
                Debug.Assert(spellCodeActionSequence != null, name + "Spell Action Sequence Object has no Action Sequence");
                if (spellCodeActionSequence != null)
                {
                    if (spellCodeActionSequence.IsExecuting)
                    {
                        spellCodeActionSequence.EndExecution();
                    }
                }
            }
            base.EndExecution();
        }
    }
}
