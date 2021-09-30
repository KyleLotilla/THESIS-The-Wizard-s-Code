using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.Actions
{
    public class SpellCodeAction : Action
    {
        [SerializeField]
        private SpellCode _spellCode;
        public SpellCode spellCode
        {
            get
            {
                return _spellCode;
            }
            set
            {
                _spellCode = value;
            }
        }
        [SerializeField]
        private ActionSequence actionSequence;
        [SerializeField]
        private List<GameObject> _actionPrefabs;
        public List<GameObject> actionPrefabs
        {
            get
            {
                return _actionPrefabs;
            }
            set
            {
                _actionPrefabs = value;
                List<Action> actions = new List<Action>();
                if (_actionPrefabs != null)
                {
                    foreach (GameObject actionPrefab in _actionPrefabs)
                    {
                        GameObject actionObject = Instantiate(actionPrefab, this.transform);
                        if (actionObject != null)
                        {
                            Action action = actionObject.GetComponent<Action>();
                            if (action != null)
                            {
                                actions.Add(action);
                            }
                        }
                    }
                    //actionSequence.ActionExecutors = actions;
                }
            }
        }

        protected override bool StartExecution()
        {
            //actionSequence.wizard = Wizard;
            actionSequence.StartExecution();
            return true;
        }

        void Start()
        {
        }

        void Update()
        {

        }

        void OnSequenceExecutionEnd()
        {
            EndExecution();
        }

        private void OnSequenceActionExecutionStart(int actionIndex)
        {
        }

        void OnSequenceActionExecutionEnd(int actionIndex)
        {
        }
    }
}
