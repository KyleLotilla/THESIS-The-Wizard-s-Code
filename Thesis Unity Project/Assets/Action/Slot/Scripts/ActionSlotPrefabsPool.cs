using DLSU.WizardCode.Spells;
using DLSU.WizardCode.UI.Slots;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.Actions.Slots
{
    public class ActionSlotPrefabsPool : MonoBehaviour
    {
        [SerializeField]
        private Dictionary<int, GameObject> spellIDActionSlotMap;
        [SerializeField]
        private Dictionary<int, GameObject> spellIDActionMap;
        [SerializeField]
        private GameObject spellActionSlotPrefab;
        [SerializeField]
        private GameObject spellCodeActionSlotPrefab;
        [SerializeField]
        private List<Sprite> spellCodeIcons;

        void Awake()
        {
            spellIDActionSlotMap = new Dictionary<int, GameObject>();
            spellIDActionMap = new Dictionary<int, GameObject>();
        }

        void Update()
        {

        }

        public GameObject GetActionSlotPrefab(SpellInstance spellInstace)
        {
            int spellID = spellInstace.spell.SpellID;
            if (spellIDActionSlotMap.ContainsKey(spellID))
            {
                return spellIDActionSlotMap[spellID];
            }
            else
            {
                return CreateActionSlotPrefab(spellInstace);
            }
        }

        private GameObject CreateActionSlotPrefab(SpellInstance spellInstance)
        {
            Spell spell = spellInstance.spell;
            GameObject actionObject = GetAction(spellInstance);
            GameObject actionSlotObject = Instantiate(spellActionSlotPrefab);
            Debug.Assert(actionSlotObject != null, name + ": Action Slot Prefab not instantiated");
            if (actionSlotObject != null && actionObject != null)
            {
                ActionHolder actionHolderOfActionSlot = actionSlotObject.GetComponent<ActionHolder>();
                IconSlot iconSlotOfActionSlot = actionSlotObject.GetComponent<IconSlot>();
                Action action = actionObject.GetComponent<Action>();
                if (actionHolderOfActionSlot != null && iconSlotOfActionSlot && action != null)
                {
                    iconSlotOfActionSlot.Icon.sprite = spellInstance.icon;
                    actionHolderOfActionSlot.Action = action;
                    actionObject.transform.SetParent(actionSlotObject.transform);
                    actionSlotObject.transform.SetParent(transform);
                    actionSlotObject.name = spell.SpellName;
                    actionSlotObject.SetActive(false);
                    spellIDActionSlotMap[spell.SpellID] = actionSlotObject;
                    return actionSlotObject;
                }
            }
            return null;
        }

        public GameObject GetActionSlot(SpellCode spellCode)
        {
            List<GameObject> actionPrefabs = new List<GameObject>();
            foreach (Spell spell in spellCode)
            {
                /*
                GameObject actionObject = GetAction(spell);
                if (actionObject != null)
                {
                    actionPrefabs.Add(actionObject);
                }
                */
            }

            GameObject spellCodeActionSlotObject = Instantiate(spellCodeActionSlotPrefab);
            if (spellCodeActionSlotObject != null)
            {
                spellCodeActionSlotObject.SetActive(false);
                //SpellCodeAction spellCodeAction = spellCodeActionSlotObject.GetComponent<SpellCodeAction>();
                /*
                if (spellCodeAction != null)
                {
                    spellCodeAction.actionPrefabs = actionPrefabs;
                    spellCodeAction.spellCode = spellCode;
                }
                */

            }
            return spellCodeActionSlotObject;
        }

        /*
        public List<GameObject> GetActionSlots(IEnumerable<SpellCode> spellCodes)
        {
            int spellIndex = 0;
            List<GameObject> actionSlots = new List<GameObject>();
            foreach (SpellCode spellCode in spellCodes)
            {
                GameObject actionSlotObject = GetActionSlot(spellCode);
                if (actionSlotObject != null)
                {
                    ActionHolder actionSlot = actionSlotObject.GetComponent<ActionHolder>();
                    if (actionSlot != null)
                    {
                        actionSlot.Icon.sprite = spellCodeIcons[spellIndex];
                        spellIndex++;
                    }
                    actionSlots.Add(actionSlotObject);
                }
            }
            return actionSlots;
        }
        */

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
                slots.Add(GetActionSlotPrefab(spellInstace  ));
            }
            return slots;
        }

        private GameObject GetAction(SpellInstance spellInstance)
        {
            Spell spell = spellInstance.spell;
            if (spellIDActionMap.ContainsKey(spell.SpellID))
            {
                return spellIDActionMap[spell.SpellID];
            }
            else
            {
                return CreateAction(spellInstance);
            }
        }

        private GameObject CreateAction(SpellInstance spellInstance)
        {
            Spell spell = spellInstance.spell;
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
                        spellIDActionMap[spell.SpellID] = actionObject;
                        return actionObject;
                    }
                }
            }
            return null;
        }
    }

}

