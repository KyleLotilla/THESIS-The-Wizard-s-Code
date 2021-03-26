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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
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
                    if (dialogueDatabase.GetDialogue(DialogueID).text.Contains(test))
                    {
                        DialogueText.text = dialogueDatabase.GetDialogue(DialogueID).text.Replace(test, "<b>" + test + "</b>");
                    }
                }
                else
                {
                    DialogueText.text = dialogueDatabase.GetDialogue(DialogueID).text;
                }
                Time.timeScale = 0;
            }
            Destroy(this.gameObject);
        }
    }
}

