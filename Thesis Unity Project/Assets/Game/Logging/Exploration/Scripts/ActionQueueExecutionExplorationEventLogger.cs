using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Actions;
using DLSU.WizardCode.Spells;
using DLSU.WizardCode.SpellCodes;
using DLSU.WizardCode.ScriptableObjectVariables;
using DLSU.WizardCode.Exploration.Time;
using System.Xml.Linq;

namespace DLSU.WizardCode.Logging.Exploration
{
    public class ActionQueueExecutionExplorationEventLogger : MonoBehaviour
    {
        [SerializeField]
        private ExplorationLogger explorationLogger;
        [SerializeField]
        private ExplorationTime explorationTime;
        [SerializeField]
        private GameObjectVariable actionQueueObject;

        private ActionSequence actionSequenceOfActionQueue;

        private void Start()
        {
            actionSequenceOfActionQueue = actionQueueObject.Value.GetComponent<ActionSequence>();
            Debug.Assert(actionSequenceOfActionQueue != null, name + ": Action Sequence not found in Action Queue");
        }

        public void LogActionQueueExecution()
        {
            XElement actionsElement = new XElement("Actions");
            foreach (ActionExecutor actionExecutor in actionSequenceOfActionQueue.ActionExecutors)
            {
                Action action = actionExecutor.Action;
                if (action != null)
                {
                    XElement actionElement = new XElement("Action");
                    actionElement.Add(new XElement("ActionType", action.ActionType));
                    if (action.ActionType == ActionType.SPELL_CODE)
                    {
                        SpellCodeHolder spellCodeHolderOfAction = action.GetComponent<SpellCodeHolder>();
                        if (spellCodeHolderOfAction != null)
                        {
                            if (spellCodeHolderOfAction != null)
                            {
                                string spellCodeName = spellCodeHolderOfAction.SpellCode.Name;
                                actionElement.Add(new XElement("Name", spellCodeName));
                                EquippedSpellCodeID equippedSpellCodeIDOfAction = action.GetComponent<EquippedSpellCodeID>();
                                if (equippedSpellCodeIDOfAction != null)
                                {
                                    int spellCodeEquippedID = equippedSpellCodeIDOfAction.ID;
                                    actionElement.Add(new XElement("SpellCodeEquippedID", spellCodeEquippedID));
                                }
                            }
                        }
                    }
                    else
                    {
                        SpellInstanceHolder spellInstanceHolder = action.GetComponent<SpellInstanceHolder>();
                        if (spellInstanceHolder != null)
                        {
                            if (spellInstanceHolder.SpellInstance != null)
                            {
                                string spellName = spellInstanceHolder.SpellInstance.Spell.SpellName;
                                actionElement.Add(new XElement("Name", spellName));
                            }
                        }
                    }
                    actionsElement.Add(actionElement);
                }
            }

            if (actionsElement.HasElements)
            {
                XElement actionQueueExecutionElement = new XElement("ActionQueueExecution");
                string formattedTimeStampString = explorationTime.FormattedTimeStampString;
                actionQueueExecutionElement.Add(new XElement("TimeStamp", formattedTimeStampString));
                actionQueueExecutionElement.Add(actionsElement);
                explorationLogger.AddExplorationLogEvent(actionQueueExecutionElement);
            }
        }
    }

}