using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionStack : MonoBehaviour
{
    /*[SerializeField]
    private Inventory inventory;
    [SerializeField]
    private EquipmentActionDatabase equipmentActionDatabase;*/
    [SerializeField]
    private GameObject slots;
    [SerializeField]
    private List<GameObject> actionsPrefabs;
    [SerializeField]
    private float spawnRate;
    [SerializeField]
    private float delta = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        /*foreach (ItemInstance equipment in inventory.Equipped)
        {
            GameObject action = equipmentActionDatabase.GetAction(equipment.Item.Id);
            if (action != null)
            {
                actionsPrefabs.Add(action);
            }
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.IsSlotsFull())
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
        bool insertedAction = false;
        for (int i = 0; i < this.slots.transform.childCount && !insertedAction; i++)
        {
            Transform slot = this.slots.transform.GetChild(i);
            if (slot.childCount == 0)
            {
                int randomIndex = Random.Range(0, this.actionsPrefabs.Count);
                Instantiate(this.actionsPrefabs[randomIndex], slot);
                insertedAction = true;
            }
        }
    }

    private bool IsSlotsFull()
    {
        bool emptySlot = false;
        for (int i = 0; i < this.slots.transform.childCount && !emptySlot; i++)
        {
            if (this.slots.transform.GetChild(i).childCount == 0)
            {
                emptySlot = true;
            }
        }
        return !emptySlot;
    }
}
