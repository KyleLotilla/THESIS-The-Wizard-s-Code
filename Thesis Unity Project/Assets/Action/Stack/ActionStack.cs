using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionStack : MonoBehaviour
{
    [SerializeField]
    private bool _isRunning = true;
    public bool isRunning
    {
        get
        {
            return _isRunning;
        }
        set
        {
            _isRunning = value;
        }
    }

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
    [SerializeField]
    private int maxActions;
    [SerializeField]
    private int maxMovementActions;
    [SerializeField]
    private int movementSpawnRate;
    [SerializeField]
    private Vector2 slotSize;
    [SerializeField]
    private Vector2 offset;
    [SerializeField]
    private float spawnRate;
    [SerializeField]
    private float resetSpawnRate;
    public bool isTutorialMovementOnly;

    private int movementActionCount = 0;
    private int actionCount = 0;
    private bool isReset = false;
    private int resetActionCount = 0;
    private List<GameObject> movementActions;
    private List<GameObject> spellActions;
    private List<GameObject> spellCodeActions;
    private List<GameObject> spawnedActions;
    private float delta = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        spellActions = actionSlotFactory.GetActionSlots(spellInventory.equipped);
        spellCodeActions = actionSlotFactory.GetActionSlots(spellCodeInventory.equipped);
        spawnedActions = new List<GameObject>();

        movementActions = new List<GameObject>();
        GameObject moveLeftPrefab = actionSlotFactory.GetActionSlot(spellDatabase.GetSpell(moveLeftID));
        if (moveLeftPrefab != null)
        {
            movementActions.Add(moveLeftPrefab);
        }
        GameObject moveRightPrefab = actionSlotFactory.GetActionSlot(spellDatabase.GetSpell(moveRightID));
        if (moveRightPrefab != null)
        {
            movementActions.Add(moveRightPrefab);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            if (isTutorialMovementOnly)
            {
                if (movementActionCount < maxMovementActions)
                {
                    delta += Time.deltaTime;
                    if (delta >= spawnRate)
                    {
                        delta = 0.0f;
                        SpawnRandomMovementAction();
                    }
                }
            }
            else if (actionCount < maxActions)
            {
                delta += Time.deltaTime;
                if (isReset && delta >= resetSpawnRate)
                {
                    this.SpawnRandomAction();
                    this.delta = 0.0f;
                    resetActionCount++;
                    if (resetActionCount >= maxActions)
                    {
                        isReset = false;
                        resetActionCount = 0;
                    }
                }
                else if (this.delta >= spawnRate)
                {
                    this.SpawnRandomAction();
                    this.delta = 0.0f;
                }
            }
        }
    }

    public void ResetStack()
    {
        foreach (GameObject actionObject in spawnedActions)
        {
            Destroy(actionObject);
        }
        delta = 0.0f;
        spawnedActions.Clear();
        isReset = true;
        resetActionCount = 0;
    }

    public void SpawnRandomAction()
    {
        int roll = Random.Range(1, 101);
        if (spellActions.Count > 0 || spellCodeActions.Count > 0)
        {
            if (movementActionCount < maxMovementActions)
            {
                if (roll <= movementSpawnRate)
                {
                    SpawnRandomMovementAction();
                }
                else if (roll <= movementSpawnRate + ((100 - movementSpawnRate) / 2))
                {
                    if (spellActions.Count > 0)
                    {
                        SpawnRandomSpellAction();
                    }
                    else if (spellCodeActions.Count > 0)
                    {
                        SpawnRandomSpellCodeAction();
                    }
                }
                else
                {
                    if (spellCodeActions.Count > 0)
                    {
                        SpawnRandomSpellCodeAction();
                    }
                    else if (spellActions.Count > 0)
                    {
                        SpawnRandomSpellAction();
                    }
                }
            }
            else
            {
                if (roll <= 50)
                {
                    if (spellActions.Count > 0)
                    {
                        SpawnRandomSpellAction();
                    }
                    else if (spellCodeActions.Count > 0)
                    {
                        SpawnRandomSpellCodeAction();
                    }
                }
                else
                {
                    if (spellCodeActions.Count > 0)
                    {
                        SpawnRandomSpellCodeAction();
                    }
                    else if (spellActions.Count > 0)
                    {
                        SpawnRandomSpellAction();
                    }
                }
            }
        }
        else
        {
            SpawnRandomMovementAction();
        }
        
    }

    public void SpawnRandomMovementAction()
    {
        if (movementActions.Count > 0)
        {
            SpawnMovementAction(Random.Range(0, movementActions.Count));
        }
    }

    public void SpawnMovementAction(int index)
    {
        if (index < movementActions.Count && index >= 0)
        {
            SpawnAction(movementActions[index]);
            movementActionCount++;
        }
    }

    public void SpawnRandomSpellAction()
    {
        if (spellActions.Count > 0)
        {
            SpawnSpellAction(Random.Range(0, spellActions.Count));
        }
    }

    public void SpawnSpellAction(int index)
    {
        if (index < spellActions.Count && index >= 0)
        {
            SpawnAction(spellActions[index]);
        }
    }

    public void SpawnRandomSpellCodeAction()
    {
        if (spellCodeActions.Count > 0)
        {
            SpawnSpellCodeAction(Random.Range(0, spellCodeActions.Count));
        }
    }

    public void SpawnSpellCodeAction(int index)
    {
        if (index < spellCodeActions.Count && index >= 0)
        {
            GameObject actionSlotObject = SpawnAction(spellCodeActions[index]);
            if (actionSlotObject != null)
            {
                ActionSlot actionSlot = actionSlotObject.GetComponent<ActionSlot>();
                if (actionSlot != null)
                {
                    SpellCodeAction actionPrefab = spellCodeActions[index].GetComponent<SpellCodeAction>();
                    SpellCodeAction action = actionSlot.action.GetComponent<SpellCodeAction>();
                    if (action != null && actionPrefab != null)
                    {
                        action.spellCode = actionPrefab.spellCode;
                    }
                }
            }
        }
    }

    private GameObject SpawnAction(GameObject actionSlotPrefab)
    {
        GameObject actionSlotObject = Instantiate(actionSlotPrefab, this.transform);
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
                actionCount++;
            }
            if (rectTransform != null)
            {
                rectTransform.sizeDelta = slotSize;
                rectTransform.anchorMin = new Vector2(0.5f, 1.0f);
                rectTransform.anchorMax = new Vector2(0.5f, 1.0f);
                rectTransform.anchoredPosition = offset;
            }
            spawnedActions.Add(actionSlotObject);
            return actionSlotObject;
        }
        else
        {
            return null;
        }
    }


    private void DeleteAction(Action action)
    {
        actionCount--;
        if (action.isMovement && movementActionCount > 0)
        {
            movementActionCount--;
        }
    }
}
