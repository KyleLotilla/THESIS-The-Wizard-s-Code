using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionStack : MonoBehaviour
{
    [SerializeField]
    private SpellInventory spellInventory;
    [SerializeField]
    private List<DropSpace> actionSpaces;
    [SerializeField]
    private List<GameObject> actionsPrefabs;
    [SerializeField]
    private List<int> slotIDPool;
    [SerializeField]
    private float spawnRate;
    [SerializeField]
    private float delta = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> actionSlots = spellInventory.GetEquippedActionSlots();

        foreach(GameObject actionSlot in actionSlots)
        {
            actionsPrefabs.Add(actionSlot);
        }

        for (int i = 0; i < actionSpaces.Count; i++)
        {
            slotIDPool.Add(i);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (slotIDPool.Count > 0)
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
        if (slotIDPool.Count > 0)
        {
            int randomActionIndex = Random.Range(0, this.actionsPrefabs.Count);
            int slotID = slotIDPool[0];
            GameObject action = Instantiate(actionsPrefabs[randomActionIndex]);
            if (action != null)
            {
                slotIDPool.RemoveAt(0);
                ActionSlot actionSlot = action.GetComponent<ActionSlot>();
                if (actionSlot != null)
                {
                    actionSpaces[slotID].slot = action;
                    actionSlot.slotID = slotID;
                }
            }
        }
    }

    public void DeleteAction(int slotID)
    {
        if (slotID >= 0 && slotID < actionSpaces.Count && !slotIDPool.Contains(slotID))
        {
            GameObject slot = actionSpaces[slotID].slot;
            actionSpaces[slotID].slot = null;
            DestroyImmediate(slot);
            slotIDPool.Add(slotID);
        }
    }
}
