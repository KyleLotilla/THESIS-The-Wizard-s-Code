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
    private GameObject rightArrow;

    [SerializeField]
    private GameObject leftArrow;


    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

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

    public void displayArrow()
    {
        if(StartIndex == 3 || StartIndex == 4)
        {
            rightArrow.SetActive(true);
            leftArrow.SetActive(false);
        }

        else if(StartIndex == 5 || StartIndex == 6)
        {
            rightArrow.SetActive(false);
            leftArrow.SetActive(true);
        }

        else
        {
            rightArrow.SetActive(false);
            leftArrow.SetActive(false);
        }
        
    }

    public bool DisplayImage()
    {
        if (dialogueDatabase.GetDialogue(StartIndex).image != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void setText()
    {
        displayArrow();
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
            dialogueDatabase.setPath("Dialogue/" + pathToXMLDatabase);
            DialoguePanel.GetComponent<DialoguePanelScript>().setCurrentDialogueEvent(this.gameObject);
            setText();
            
        }
        
    }
}

