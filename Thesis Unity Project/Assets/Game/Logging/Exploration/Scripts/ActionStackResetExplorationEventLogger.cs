using DLSU.WizardCode.Actions;
using DLSU.WizardCode.Actions.Stack;
using DLSU.WizardCode.ScriptableObjectVariables;
using DLSU.WizardCode.SpellCodes;
using DLSU.WizardCode.Spells;
using DLSU.WizardCode.Exploration.Time;
using System.Xml.Linq;
using UnityEngine;

namespace DLSU.WizardCode.Logging.Exploration
{
    public class ActionStackResetExplorationEventLogger : MonoBehaviour
    {
        [SerializeField]
        private GameObjectVariable actionStackObject;
        [SerializeField]
        private IntVariable actionStackResetCount;
        [SerializeField]
        private ExplorationLogger explorationLogger;
        [SerializeField]
        private ExplorationTime explorationTime;

        private ActionStack actionStack;
        private XElement actionsInStackBeforeResetElement;

        private void Start()
        {
            actionStack = actionStackObject.Value.GetComponent<ActionStack>();
            Debug.Assert(actionStack != null, name + ": Action Stack not found");
        }

        public void LogResetActionStack()
        {
            XElement actionStackResetElement = new XElement("ActionStackReset");
            string formattedTimeStampString = explorationTime.FormattedTimeStampString;
            actionStackResetElement.Add(new XElement("TimeStamp", formattedTimeStampString));
            actionStackResetElement.Add(new XElement("ResetsRemaining", actionStackResetCount.Value));
            actionStackResetElement.Add(actionsInStackBeforeResetElement);
            explorationLogger.AddExplorationLogEvent(actionStackResetElement);
        }

        public void LogActionsInStackBeforeReset()
        {
            actionsInStackBeforeResetElement = new XElement("ActionsInStackBeforeReset");
            foreach (GameObject spawnedActionObject in actionStack.SpawnedActionObjects)
            {
                ActionHolder actionHolder = spawnedActionObject.GetComponent<ActionHolder>();
                if (actionHolder != null)
                {
                    if (actionHolder.Action != null)
                    {
                        Action action = actionHolder.Action;
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
                        actionsInStackBeforeResetElement.Add(actionElement);
                    }
                }
            }
        }
    }

}
