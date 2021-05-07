using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellCodeEditSaveUI : MonoBehaviour
{
    [SerializeField]
    private SpellCodeInventory spellCodeInventory;
    [SerializeField]
    private Text missingNameText;
    [SerializeField]
    private Text spellLimitText;
    [SerializeField]
    private InputField nameField;
    [SerializeField]
    private Button button;
    private IEnumerable<GameObject> _spaces;
    public IEnumerable<GameObject> spaces
    {
        get
        {
            return _spaces;
        }
        set
        {
            _spaces = value;
            foreach(GameObject spaceObject in _spaces)
            {
                SlotSpace space = spaceObject.GetComponent<SlotSpace>();
                if (space != null)
                {
                    space.OnSlotChange += OnSlotChange;
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSlotChange(GameObject newSlot)
    {
        Refresh();
    }
    public void Refresh()
    {
        bool hasMinSpells = false;
        bool hasName = false;

        int spellCount = 0;
        foreach (GameObject spaceObject in spaces)
        {
            SlotSpace space = spaceObject.GetComponent<SlotSpace>();
            if (space != null)
            {
                GameObject slot = space.slot;
                if (slot != null)
                {
                    spellCount++;
                }
            }
        }
 
        if (spellCount < spellCodeInventory.minSpells)
        {
            spellLimitText.gameObject.SetActive(true);
        }
        else
        {
            hasMinSpells = true;
            spellLimitText.gameObject.SetActive(false);
        }

        if (nameField.text.Length <= 0)
        {
            missingNameText.gameObject.SetActive(true);
        }
        else
        {
            hasName = true;
            missingNameText.gameObject.SetActive(false);
        }

        if (hasMinSpells && hasName)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }
}
