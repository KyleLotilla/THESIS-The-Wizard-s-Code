using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotMenu<T> : MonoBehaviour
{
    [SerializeField]
    private GameObject slotPrefab;
    [SerializeField]
    private GameObject spacePrefab;
    protected IEnumerable<T> items;
    [SerializeField]
    private bool fillExtraSlots = true;
    [SerializeField]
    protected int slotCount = 0;
    [SerializeField]
    private int _maxSpaces;
    public int maxSpaces
    {
        get
        {
            return _maxSpaces;
        }
        set
        {
            _maxSpaces = value;
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RefreshMenu()
    {
        RemoveAllSpaces();
        if (items != null)
        {
            foreach (T item in items)
            {
                GameObject space = null;
                if (spacePrefab != null)
                {
                    space = Instantiate(spacePrefab, this.transform);
                }
                GameObject slot = Instantiate(slotPrefab, this.transform);
                if (space != null)
                {
                    slot.transform.SetParent(space.transform);
                }
                OnSlotSpawn(slot, space, item);
                slotCount++;
            }
        }

        if (spacePrefab != null && fillExtraSlots)
        {
            for (int i = slotCount; i < maxSpaces; i++)
            {
                GameObject space = Instantiate(spacePrefab, this.transform);
                OnEmptySpaceSpawn(space);
            }
        }

    }

    protected virtual void OnSlotSpawn(GameObject slot, GameObject space, T item)
    {

    }

    protected virtual void OnEmptySpaceSpawn(GameObject space)
    {

    }

    void RemoveAllSpaces()
    {
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }
        slotCount = 0;
    }
}
