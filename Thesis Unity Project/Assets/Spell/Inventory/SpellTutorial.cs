using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellTutorial : MonoBehaviour
{
    [SerializeField]
    private ShowDialogue showDialogue;
    [SerializeField]
    private Button levelSelectButton;
    [SerializeField]
    private Button spellButton;
    [SerializeField]
    private SpellEquipmentMenu spellEquipmentMenu;
    private List<SlotSpace> spaces;

    // Start is called before the first frame update
    void Start()
    {
        spaces = new List<SlotSpace>();
        foreach(GameObject spaceObject in spellEquipmentMenu.spaces)
        {
            SlotSpace space = spaceObject.GetComponent<SlotSpace>();
            if (space != null)
            {
                spaces.Add(space);
                space.OnSlotChange += OnSlotChange;
            }
        }
    }

    private void OnSlotChange(GameObject newSlot)
    {
        foreach (SlotSpace space in spaces)
        {
            space.OnSlotChange -= OnSlotChange;
        }
        showDialogue.Show();
        spellButton.interactable = false;
        levelSelectButton.interactable = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
