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
    private Text username;

    [SerializeField]
    private int StartIndex;

    [SerializeField]
    private int EndIndex;

    [SerializeField]
    private GameObject GuideImage;

    

    void Start()
    {
        Sprite temp;
        temp = Resources.Load<Sprite>("Dialogue/VisualGuide/TempGif");
       // GuideImage.sprite = temp;
        
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
        Time.timeScale = 1;
    }

    public void setText()
    {
        GuideImage.SetActive(false);
        if (dialogueDatabase.GetDialogue(StartIndex) != null)
        {
            DialoguePanel.SetActive(true);
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
            if(dialogueDatabase.GetDialogue(StartIndex).imagepath != null)
            {
                GuideImage.SetActive(true);
                GuideImage.GetComponent<Image>().sprite = dialogueDatabase.GetDialogue(StartIndex).image;
            }
            /*
            if (DialogueID == 0)
            {
                if (dialogueDatabase.setPlayerName(username.text, dialogueDatabase.GetDialogue(DialogueID).text) != null)
                {
                    DialogueText.text = dialogueDatabase.setPlayerName(username.text, dialogueDatabase.GetDialogue(DialogueID).text);
                }
                else
                {
                    DialogueText.text = dialogueDatabase.GetDialogue(DialogueID).text;
                }
            }
            */
            //Time.timeScale = 0;
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        dialogueDatabase.setPath("Dialogue/" + pathToXMLDatabase);
        
        if (col.gameObject.tag == "Wizard")
        {
            DialoguePanel.GetComponent<DialoguePanelScript>().setCurrentDialogueEvent(this.gameObject);
            setText();
           
        }
    }
}

