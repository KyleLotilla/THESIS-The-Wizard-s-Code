using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellCodeEditSaveUI : MonoBehaviour
{
    /*
    [SerializeField]
    private SpellCodeInventory spellCodeInventory;
    */
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
                /*
                SlotSpace space = spaceObject.GetComponent<SlotSpace>();
                if (space != null)
                {
                    space.OnSlotChange += OnSlotChange;
                }
                */
            }
        }
    }
    [SerializeField]
    private bool isTutorial = false;
    [SerializeField]
    private int moveRightID;
    [SerializeField]
    private int fireballID;

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
        bool hasTutorialSpells = false;

        int spellCount = 0;
        int moveRightCount = 0;
        int fireballCount = 0;

        foreach (GameObject spaceObject in spaces)
        {
            /*
            SlotSpace space = spaceObject.GetComponent<SlotSpace>();
            if (space != null)
            {
                GameObject slot = space.slot;
                if (slot != null)
                {
                    spellCount++;
                    if (isTutorial)
                    {
                        SpellSlot spellSlot = slot.GetComponent<SpellSlot>();
                        if (spellSlot != null)
                        {
                            if (moveRightID == spellSlot.spell.spellID)
                            {
                                moveRightCount++;
                            }
                            else if (fireballID == spellSlot.spell.spellID)
                            {
                                fireballCount++;
                            }
                        }
                    }
                }
            }
            */
        }

        /*
        if (spellCount < spellCodeInventory.minSpells)
        {
            spellLimitText.gameObject.SetActive(true);
            if (isTutorial)
            {
                spellLimitText.text = "SpellCode needs at least 2 Spells";
            }
        }
        else if (isTutorial)
        {
            hasMinSpells = true;
            if (moveRightCount < 1 || fireballCount < 1)
            {
                spellLimitText.text = "SpellCode needs 1 fireball spell and 1 forward movement";
                spellLimitText.gameObject.SetActive(true);
            }
            else
            {
                spellLimitText.gameObject.SetActive(false);
                hasTutorialSpells = true;
            }
        }
        else
        {
            hasMinSpells = true;
            spellLimitText.gameObject.SetActive(false);
        }
        */
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
            if (!isTutorial)
            {
                button.interactable = true;
            }
            else
            {
                if (hasTutorialSpells)
                {
                    button.interactable = true;
                }
                else
                {
                    button.interactable = false;
                }
            }
        }
        else
        {
            button.interactable = false;
        }
    }
}
