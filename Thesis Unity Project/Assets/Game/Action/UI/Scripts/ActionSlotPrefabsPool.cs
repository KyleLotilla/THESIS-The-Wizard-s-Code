using DLSU.WizardCode.Spells;
using DLSU.WizardCode.UI.Slots;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.SpellCodes;
using DLSU.WizardCode.SpellCodes.UI;
using DLSU.WizardCode.UI.Views;
using DLSU.WizardCode.SpellCodes.Actions;

namespace DLSU.WizardCode.Actions.UI
{
    public class ActionSlotPrefabsPool : MonoBehaviour
    {
        [SerializeField]
        private GameObject actionSlotPrefab;
        [SerializeField]
        private GameObject baseSpellCodeActionPrefab;
        [SerializeField]
        private SpellCodeInventory spellCodeInventory;
        [SerializeField]
        private SpellCodeIcons spellCodeIcons;

        private Dictionary<int, GameObject> spellIDActionSlotPrefabMap;
        private Dictionary<int, GameObject> spellIDActionPrefabMap;
        private Dictionary<SpellCode, GameObject> spellCodeActionSlotPrefabMap;

        void Awake()
        {
            spellIDActionSlotPrefabMap = new Dictionary<int, GameObject>();
            spellIDActionPrefabMap = new Dictionary<int, GameObject>();
            spellCodeActionSlotPrefabMap = new Dictionary<SpellCode, GameObject>();
        }

        public GameObject GetActionSlotPrefab(SpellInstance spellInstace)
        {
            int spellID = spellInstace.Spell.SpellID;
            if (spellIDActionSlotPrefabMap.ContainsKey(spellID))
            {
                return spellIDActionSlotPrefabMap[spellID];
            }
            else
            {
                return CreateActionSlotPrefab(spellInstace);
            }
        }

        private GameObject CreateActionSlotPrefab(SpellInstance spellInstance)
        {
            Spell spell = spellInstance.Spell;
            GameObject actionPrefab = GetActionPrefab(spellInstance);
            GameObject actionSlotPrefab = Instantiate(this.actionSlotPrefab, transform);
            Debug.Assert(actionSlotPrefab != null, name + ": Action Slot Prefab not instantiated");
            if (actionSlotPrefab != null && actionPrefab != null)
            {
                ActionHolder actionHolderOfActionSlot = actionSlotPrefab.GetComponent<ActionHolder>();
                IconView iconViewOfActionSlot = actionSlotPrefab.GetComponent<IconView>();
                Action action = actionPrefab.GetComponent<Action>();
                if (actionHolderOfActionSlot != null && iconViewOfActionSlot && action != null)
                {
                    iconViewOfActionSlot.Icon.sprite = spellInstance.Icon;
                    actionHolderOfActionSlot.Action = action;
                    actionPrefab.transform.SetParent(actionSlotPrefab.transform);
                    actionSlotPrefab.name = spell.SpellName;
                    actionSlotPrefab.SetActive(false);
                    spellIDActionSlotPrefabMap[spell.SpellID] = actionSlotPrefab;
                    return actionSlotPrefab;
                }
            }
            return null;
        }

        private GameObject CreateActionPrefab(SpellInstance spellInstance)
        {
            Spell spell = spellInstance.Spell;
            Debug.Assert(spell.ActionPrefab != null, name + ": " + spell.name + " has no Action");
            if (spell.ActionPrefab != null)
            {
                GameObject actionObject = Instantiate(spell.ActionPrefab);
                if (actionObject != null)
                {
                    Action action = actionObject.GetComponent<Action>();
                    if (action != null)
                    {
                        SpellInstanceHolder spellInstanceHolder = actionObject.GetComponent<SpellInstanceHolder>();
                        if (spellInstanceHolder != null)
                        {
                            spellInstanceHolder.SpellInstance = spellInstance;
                        }
                        actionObject.transform.SetParent(transform);
                        spellIDActionPrefabMap[spell.SpellID] = actionObject;
                        return actionObject;
                    }
                }
            }
            return null;
        }

        public List<GameObject> GetActionSlotPrefabs(List<SpellInstance> spellInstances)
        {
            List<GameObject> slots = new List<GameObject>();
            foreach (SpellInstance spellInstance in spellInstances)
            {
                slots.Add(GetActionSlotPrefab(spellInstance));
            }
            return slots;
        }

        public List<GameObject> GetActionSlotPrefabs(IEnumerable<SpellInstance> spellInstances)
        {
            List<GameObject> slots = new List<GameObject>();
            foreach (SpellInstance spellInstace in spellInstances)
            {
                slots.Add(GetActionSlotPrefab(spellInstace));
            }
            return slots;
        }

        public GameObject GetActionSlotPrefab(SpellCode spellCode)
        {
            if (spellCodeActionSlotPrefabMap.ContainsKey(spellCode))
            {
                return spellCodeActionSlotPrefabMap[spellCode];
            }
            else
            {
                return CreateActionSlotPrefab(spellCode);
            }
        }

        private GameObject CreateActionSlotPrefab(SpellCode spellCode)
        {
            GameObject spellCodeActionPrefab = CreateActionPrefab(spellCode);
            GameObject spellCodeActionSlotPrefab = Instantiate(actionSlotPrefab, transform);
            Debug.Assert(spellCodeActionPrefab != null, name + ": Spell Code Action Slot Prefab not instantiated");
            if (spellCodeActionPrefab != null && spellCodeActionSlotPrefab != null)
            {
                ActionHolder actionHolderOfActionSlot = spellCodeActionSlotPrefab.GetComponent<ActionHolder>();
                IconView iconSlotOfActionSlot = spellCodeActionSlotPrefab.GetComponent<IconView>();
                Action action = spellCodeActionPrefab.GetComponent<Action>();
                if (actionHolderOfActionSlot != null && iconSlotOfActionSlot && action != null)
                {
                    actionHolderOfActionSlot.Action = action;
                    spellCodeActionPrefab.transform.SetParent(spellCodeActionSlotPrefab.transform);
                    spellCodeActionSlotPrefab.name = spellCode.Name;
                    spellCodeActionSlotPrefab.SetActive(false);
                    spellCodeActionSlotPrefabMap[spellCode] = spellCodeActionSlotPrefab;
                    int spellCodeEquippedIndex = spellCodeInventory.GetEquippedSpellCodeIndex(spellCode);
                    if (spellCodeEquippedIndex > -1)
                    {
                        iconSlotOfActionSlot.Icon.sprite = spellCodeIcons.GetIcon(spellCodeEquippedIndex);
                    }
                    return spellCodeActionSlotPrefab;
                }
            }
            return null;
        }

        private GameObject GetActionPrefab(SpellInstance spellInstance)
        {
            Spell spell = spellInstance.Spell;
            if (spellIDActionPrefabMap.ContainsKey(spell.SpellID))
            {
                return spellIDActionPrefabMap[spell.SpellID];
            }
            else
            {
                return CreateActionPrefab(spellInstance);
            }
        }

        private GameObject CreateActionPrefab(SpellCode spellCode)
        {
            GameObject spellCodeActionPrefab = Instantiate(baseSpellCodeActionPrefab);
            Debug.Assert(spellCodeActionPrefab != null, name + ": Spell Code Action Prefab not Instantiated");
            if (spellCodeActionPrefab != null)
            {
                SpellCodeAction spellCodeAction = spellCodeActionPrefab.GetComponent<SpellCodeAction>();
                Debug.Assert(spellCodeAction != null, name + ": Spell Code Action not found in Spell Code Action Prefab");
                if (spellCodeAction != null)
                {
                    List<Action> spellActions = new List<Action>();
                    foreach (SpellInstance spellInstance in spellCode)
                    {
                        GameObject originalActionPrefab = GetActionPrefab(spellInstance);
                        GameObject actionPrefabForSpellCodeActionPrefab = Instantiate(originalActionPrefab, spellCodeActionPrefab.transform);
                        if (actionPrefabForSpellCodeActionPrefab != null)
                        {
                            Action action = actionPrefabForSpellCodeActionPrefab.GetComponent<Action>();
                            spellActions.Add(action);
                        }
                    }
                    spellCodeAction.SpellActions = spellActions;
                }
                SpellCodeHolder spellCodeHolderOfSpellCodeAction = spellCodeActionPrefab.GetComponent<SpellCodeHolder>();
                if (spellCodeHolderOfSpellCodeAction != null)
                {
                    spellCodeHolderOfSpellCodeAction.SpellCode = spellCode;
                }
                EquippedSpellCodeID equippedSpellCodeIDOfSpellCodeAction = spellCodeActionPrefab.GetComponent<EquippedSpellCodeID>();
                if (equippedSpellCodeIDOfSpellCodeAction != null)
                {
                    equippedSpellCodeIDOfSpellCodeAction.ID = spellCodeInventory.GetEquippedSpellCodeIndex(spellCode);
                }
            }
            return spellCodeActionPrefab;
        }

        public List<GameObject> GetActionSlotPrefabs(IEnumerable<SpellCode> spellCodes)
        {
            List<GameObject> slots = new List<GameObject>();
            foreach (SpellCode spellCode in spellCodes)
            {
                slots.Add(GetActionSlotPrefab(spellCode));
            }
            return slots;
        }
    }

}

