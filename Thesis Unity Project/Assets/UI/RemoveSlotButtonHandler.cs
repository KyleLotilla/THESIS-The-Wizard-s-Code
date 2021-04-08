using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveSlotButtonHandler : MonoBehaviour
{
    [SerializeField]
    private SlotSpace space;
    [SerializeField]
    private GameObject button; 

    // Start is called before the first frame update
    void Start()
    {
        space.OnSlotChange += OnSlotChange;
        if (!space.isEmpty)
        {
            OnSlotChange(space.slot);
        }
    }

    private void OnSlotChange(GameObject newSlot)
    {
        if (newSlot == null && button.activeSelf)
        {
            SetButtonActive(false);
        }
        else if (newSlot != null && !button.activeSelf)
        {
            SetButtonActive(true);
        }
    }

    public void SetButtonActive(bool active)
    {
        button.SetActive(active);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
