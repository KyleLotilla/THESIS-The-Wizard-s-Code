using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSlotFactory : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        spellIDActionSlotMap = new Dictionary<int, GameObject>();
        spellIDActionMap = new Dictionary<int, GameObject>();
    }

    void Update()
    {
        
    }

    public GameObject GetActionSlot(Spell spell)
    {
        if (spellIDActionSlotMap.ContainsKey(spell.spellID))
        {
            return spellIDActionSlotMap[spell.spellID];
        }
        else
        {
            GameObject actionObject = GetAction(spell);
            GameObject actionSlotObject = Instantiate(spellActionSlotPrefab);
            if (actionSlotObject != null && actionObject != null)
            {
                ActionSlot actionSlot = actionSlotObject.GetComponent<ActionSlot>();
                Action action = actionObject.GetComponent<Action>();
                if (actionSlot != null && action != null)
                {
                    actionSlot.icon.sprite = spell.icon;
                    actionSlot.action = action;
                    actionObject.transform.SetParent(actionSlotObject.transform);
                    actionSlot.gameObject.SetActive(false);
                    spellIDActionSlotMap[spell.spellID] = actionSlotObject;
                    return actionSlotObject;
                }
             }
        }
        return null;
    }

    public GameObject GetActionSlot(SpellCode spellCode)
    {
        List<GameObject> actionPrefabs = new List<GameObject>();
        foreach (Spell spell in spellCode)
        {
            GameObject actionObject = GetAction(spell);
            if (actionObject != null)
            {
                actionPrefabs.Add(actionObject);
            }
        }

        GameObject spellCodeActionSlotObject = Instantiate(spellCodeActionSlotPrefab);
        if (spellCodeActionSlotObject != null)
        {
            spellCodeActionSlotObject.SetActive(false);
            SpellCodeAction spellCodeAction = spellCodeActionSlotObject.GetComponent<SpellCodeAction>();
            if (spellCodeAction != null)
            {
                spellCodeAction.actionPrefabs = actionPrefabs;
                spellCodeAction.spellCode = spellCode;
            }
            
        }
        return spellCodeActionSlotObject;
    }


    public List<GameObject> GetActionSlots(IEnumerable<SpellCode> spellCodes)
    {
        int spellIndex = 0;
        List<GameObject> actionSlots = new List<GameObject>();
        foreach (SpellCode spellCode in spellCodes)
        {
            GameObject actionSlotObject = GetActionSlot(spellCode);
            if (actionSlotObject != null)
            {
                ActionSlot actionSlot = actionSlotObject.GetComponent<ActionSlot>();
                if (actionSlot != null)
                {
                    actionSlot.icon.sprite = spellCodeIcons[spellIndex];
                    spellIndex++;
                }
                actionSlots.Add(actionSlotObject);
            }
        }
        return actionSlots;
    }

    public List<GameObject> GetActionSlots(List<Spell> spells)
    {
        List<GameObject> slots = new List<GameObject>();
        foreach (Spell spell in spells)
        {
            slots.Add(GetActionSlot(spell));
        }
        return slots;
    }

    public List<GameObject> GetActionSlots(IEnumerable<Spell> spells)
    {
        List<GameObject> slots = new List<GameObject>();
        foreach (Spell spell in spells)
        {
            slots.Add(GetActionSlot(spell));
        }
        return slots;
    }

    private GameObject GetAction(Spell spell)
    {
        if (spellIDActionMap.ContainsKey(spell.spellID))
        {
            return spellIDActionMap[spell.spellID];
        }
        else
        {
            GameObject actionPrefab = Resources.Load<GameObject>(spell.actionPath);
            if (actionPrefab != null)
            {
                GameObject actionObject = Instantiate(actionPrefab);
                if (actionObject != null)
                {
                    Action action = actionObject.GetComponent<Action>();
                    if (action != null)
                    {
                        spellIDActionMap[spell.spellID] = actionObject;
                        return actionObject;
                    }
                }
            }
        }
        return null;
    }
}
