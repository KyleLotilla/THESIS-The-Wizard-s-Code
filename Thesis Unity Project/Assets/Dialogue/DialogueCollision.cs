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
    private int StartIndex;

    [SerializeField]
    private int EndIndex;

    [SerializeField]
    private Text username;

    [SerializeField]
    private GameObject guideImage;

    [SerializeField]
    private GameObject fairyTalk;

    [SerializeField]
    private float fairyTalkLifetime;

    private bool collided;

   
    private GameObject Wizard;
    


    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (fairyTalk.activeSelf && this.collided)
        {
            //Debug.Log(this.gameObject.ToString());
            this.fairyTalkLifetime -= Time.deltaTime;
            //Debug.Log(this.fairyTalkLifetime);
            Destroy(this.gameObject.GetComponent<SpriteRenderer>());
            this.Wizard.GetComponent<WizardMovement>().StopWalking();


            if (this.fairyTalkLifetime < 0.0f)
            {
                fairyTalk.SetActive(false);
                dialogueDatabase.setPath("Dialogue/" + pathToXMLDatabase);
                DialoguePanel.GetComponent<DialoguePanelScript>().setCurrentDialogueEvent(this.gameObject);
                setText();
            }
        }
    }

    public void NextText()
    {
        StartIndex = StartIndex + 1;
    }

    public int getStartIndex()
    {
        return StartIndex;
    }

    public int getEndIndex()
    {
        return EndIndex;
    }

    public void DestroyObject()
    {
        Destroy(this.gameObject);
    }

    public string displayArrow()
    {
        if(dialogueDatabase.GetDialogue(StartIndex).Arrow != null)
        {
            return dialogueDatabase.GetDialogue(StartIndex).Arrow;
        }
        else
        {
            return null;
        }
        
    }

    public int DisplayPage()
    {
        if(dialogueDatabase.GetDialogue(StartIndex).page != 0)
        {
            return dialogueDatabase.GetDialogue(StartIndex).page - 1;
        }
        else
        {
            return -1;
        }
    }

    public void setText()
    {
        if (dialogueDatabase.GetDialogue(StartIndex) != null)
        {
            DialoguePanel.SetActive(true);
            guideImage.SetActive(false);
            
            //Debug.Log(dialogueDatabase.GetDialogue().text);
            if (dialogueDatabase.GetDialogue(StartIndex).bold != null)
            {
                string test = dialogueDatabase.GetDialogue(StartIndex).bold;
                if (dialogueDatabase.setBold(test, dialogueDatabase.GetDialogue(StartIndex).text) != null)
                {
                    DialogueText.text = dialogueDatabase.setBold(test, dialogueDatabase.GetDialogue(StartIndex).text);
                }
            }
            else
            {
                DialogueText.text = dialogueDatabase.GetDialogue(StartIndex).text;
            }
            

            if (StartIndex == 0)
            {
                if (dialogueDatabase.setPlayerName(username.text, dialogueDatabase.GetDialogue(StartIndex).text) != null)
                {
                    DialogueText.text = dialogueDatabase.setPlayerName(username.text, dialogueDatabase.GetDialogue(StartIndex).text);
                }
                else
                {
                    DialogueText.text = dialogueDatabase.GetDialogue(StartIndex).text;
                }
            }
            Time.timeScale = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Wizard")
        {
            this.Wizard = col.gameObject;
            col.gameObject.GetComponent<WizardMovement>().StopWalking();
            /*dialogueDatabase.setPath("Dialogue/" + pathToXMLDatabase);
            DialoguePanel.GetComponent<DialoguePanelScript>().setCurrentDialogueEvent(this.gameObject);
            setText();*/
            this.collided = true;
            //Debug.Log("Collided with " + this.gameObject.ToString());
            fairyTalk.SetActive(true);
        }
    }

    void DisplayDialogue() 
    {
        dialogueDatabase.setPath("Dialogue/" + pathToXMLDatabase);
        DialoguePanel.GetComponent<DialoguePanelScript>().setCurrentDialogueEvent(this.gameObject);
        setText();
    }
}

