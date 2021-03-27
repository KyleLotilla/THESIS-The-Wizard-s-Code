using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingModeDialoguePanel : MonoBehaviour
{
    // Start is called before the first frame update\
    private bool setXMLDatabase = true;

    [SerializeField]
    private Text DialogueText;

    [SerializeField]
    private DialogueDatabase dialogueDatabase;

    [SerializeField]
    private string pathToXMLDatabase;

    [SerializeField]
    private int DialogueID;

    [SerializeField]
    private GameObject DialoguePanel;

    [SerializeField]
    private Button okButton;


    void Start()
    {
        if (setXMLDatabase)
        {
            dialogueDatabase.setPath("Dialogue/" + pathToXMLDatabase);
            setXMLDatabase = false;
            setText();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextText()
    {
        DialogueID = DialogueID + 1;
        setText();
    }

    public void untilCraft()
    {
        if(DialogueID < 1 || DialogueID > 1)
        {
            nextText();
        }
        else
        {
            DialoguePanel.SetActive(false);
        }
    }

    public void Aftercraft()
    {
        DialoguePanel.SetActive(true);
        nextText();
    }

    void setText()
    {
        if (dialogueDatabase.GetDialogue(DialogueID) != null)
        {
            if (dialogueDatabase.GetDialogue(DialogueID).bold != null)
            {
                string test = dialogueDatabase.GetDialogue(DialogueID).bold;
                if (dialogueDatabase.setBold(test, dialogueDatabase.GetDialogue(DialogueID).text) != null)
                {
                    DialogueText.text = dialogueDatabase.setBold(test, dialogueDatabase.GetDialogue(DialogueID).text);
                }
            }
            else
            {
                DialogueText.text = dialogueDatabase.GetDialogue(DialogueID).text;
            }
            Time.timeScale = 0;
        }
        else
        {
            DialoguePanel.SetActive(false);
        }
    }
}
