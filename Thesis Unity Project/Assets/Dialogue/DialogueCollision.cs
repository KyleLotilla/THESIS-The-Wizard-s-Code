using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueCollision : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject DialoguePanel;
    [SerializeField]
    private Text DialogueText;
    
    [SerializeField]
    private DialogueDatabase dialogueDatabase;

    [SerializeField]
    private string pathToXMLDatabase;

    [SerializeField]
    private int DialogueID;

    [SerializeField]
    private Text username;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        dialogueDatabase.setPath("Dialogue/" + pathToXMLDatabase);
        
        if (col.gameObject.tag == "Wizard")
        {
            if(dialogueDatabase.GetDialogue(DialogueID) != null)
            {
                DialoguePanel.SetActive(true);
                //Debug.Log(dialogueDatabase.GetDialogue().text);
                if(dialogueDatabase.GetDialogue(DialogueID).bold != null)
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
                if(DialogueID == 0)
                {
                    if(dialogueDatabase.setPlayerName(username.text, dialogueDatabase.GetDialogue(DialogueID).text) != null)
                    {
                        DialogueText.text = dialogueDatabase.setPlayerName(username.text, dialogueDatabase.GetDialogue(DialogueID).text);
                    }
                    else
                    {
                        DialogueText.text = dialogueDatabase.GetDialogue(DialogueID).text;
                    }
                }
                Time.timeScale = 0;
            }
            Destroy(this.gameObject);
        }
    }
}

