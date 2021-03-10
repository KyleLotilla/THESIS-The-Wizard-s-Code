using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionStack : MonoBehaviour
{
    [SerializeField]
    private Vector2 slotSize;
    [SerializeField]
    private Vector2 offset;
    [SerializeField]
    private SpellDatabase spellDatabase;
    [SerializeField]
    private int moveLeftID;
    [SerializeField]
    private int moveRightID;
    [SerializeField]
    private SpellInventory spellInventory;
    private int numSlots;
    [SerializeField]
    private int maxSlots;
    [SerializeField]
    private List<GameObject> actionsPrefabs;
    [SerializeField]
    private float spawnRate;
    [SerializeField]
    private float delta = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        actionsPrefabs = spellInventory.GetEquippedActionSlots();
        GameObject moveLeftPrefab = spellDatabase.GetActionSlot(moveLeftID);
        if (moveLeftPrefab != null)
        {
            actionsPrefabs.Add(moveLeftPrefab);
        }
        GameObject moveRightPrefab = spellDatabase.GetActionSlot(moveRightID);
        if (moveRightPrefab != null)
        {
            actionsPrefabs.Add(moveRightPrefab);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (numSlots < maxSlots)
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
            ActionSlot actionSlot = actionSlotObject.GetComponent<ActionSlot>();
            RectTransform rectTransform = actionSlotObject.GetComponent<RectTransform>();
            if (actionSlot != null)
            {
                actionSlot.OnActionSlotDestroyed += DeleteAction;
                numSlots++;
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
        numSlots--;
    }
}
