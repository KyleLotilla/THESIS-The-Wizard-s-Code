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
        Destroy(this);
    }

    public void setText()
    {
        if (dialogueDatabase.GetDialogue(StartIndex) != null)
        {
            DialoguePanel.SetActive(true);
            guideImage.SetActive(false);
            //Debug.Log(dialogueDatabase.GetDialogue().text);
            if (dialogueDatabase.GetDialogue(StartIndex).image != null)
            {
                guideImage.SetActive(true);
                guideImage.GetComponent<Image>().sprite = dialogueDatabase.GetDialogue(StartIndex).image;
            }
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
        dialogueDatabase.setPath("Dialogue/" + pathToXMLDatabase);
        DialoguePanel.GetComponent<DialoguePanelScript>().setCurrentDialogueEvent(this.gameObject);


        if (col.gameObject.tag == "Wizard")
        {
            setText();
        }
    }
}

