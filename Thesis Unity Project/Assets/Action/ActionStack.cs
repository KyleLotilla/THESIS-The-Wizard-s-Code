using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionStack : MonoBehaviour
{

    [SerializeField]
    private SpellDatabase spellDatabase;
    [SerializeField]
    private SpellInventory spellInventory;
    [SerializeField]
    private SpellCodeInventory spellCodeInventory;
    [SerializeField]
    private ActionSlotFactory actionSlotFactory;
    [SerializeField]
    private int moveLeftID;
    [SerializeField]
    private int moveRightID;
    private int slotCount;
    [SerializeField]
    private int maxSlots;
    [SerializeField]
    private List<GameObject> actionsPrefabs;
    [SerializeField]
    private Vector2 slotSize;
    [SerializeField]
    private Vector2 offset;
    [SerializeField]
    private float spawnRate;
    [SerializeField]
    private float delta = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        actionsPrefabs = actionSlotFactory.GetActionSlots(spellInventory.equipped);
        actionsPrefabs.AddRange(actionSlotFactory.GetActionSlots(spellCodeInventory.equipped));

        GameObject moveLeftPrefab = actionSlotFactory.GetActionSlot(spellDatabase.GetSpell(moveLeftID));
        if (moveLeftPrefab != null)
        {
            actionsPrefabs.Add(moveLeftPrefab);
        }
        GameObject moveRightPrefab = actionSlotFactory.GetActionSlot(spellDatabase.GetSpell(moveRightID));
        if (moveRightPrefab != null)
        {
            actionsPrefabs.Add(moveRightPrefab);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (slotCount < maxSlots)
        {
            delta += Time.deltaTime;
            if (this.delta >= spawnRate)
            {
                this.SpawnAction();
                this.delta = 0.0f;
            }
        }
    }

    private void SpawnAction()
    {
        int randomActionIndex = Random.Range(0, this.actionsPrefabs.Count);
        GameObject actionSlotObject = Instantiate(actionsPrefabs[randomActionIndex], this.transform);
        if (actionSlotObject != null)
        {
            if (!actionSlotObject.activeSelf)
            {
                actionSlotObject.SetActive(true);
            }
            ActionSlot actionSlot = actionSlotObject.GetComponent<ActionSlot>();
            RectTransform rectTransform = actionSlotObject.GetComponent<RectTransform>();
            if (actionSlot != null)
            {
                actionSlot.OnActionSlotDestroyed += DeleteAction;
                slotCount++;
                if (actionSlotObject.tag == "SpellCodeAction")
                {
                    SpellCodeAction actionPrefab = actionsPrefabs[randomActionIndex].GetComponent<SpellCodeAction>();
                    SpellCodeAction action = actionSlot.action.GetComponent<SpellCodeAction>();
                    if (action != null && actionPrefab != null)
                    {
                        action.spellCode = actionPrefab.spellCode;
                    }
            }
            }
            if (rectTransform != null)
            {
                rectTransform.sizeDelta = slotSize;
                rectTransform.anchorMin = new Vector2(0.5f, 1.0f);
                rectTransform.anchorMax = new Vector2(0.5f, 1.0f);
                rectTransform.anchoredPosition = offset;
            }
            
        }
    }

    private void DeleteAction()
    {
        slotCount--;
    }
}
