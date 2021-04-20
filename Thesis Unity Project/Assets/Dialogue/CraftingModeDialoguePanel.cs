using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

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

    [SerializeField]
    private AudioSource buttonSFX;

    private bool textDisplay = true;

    /*
    [SerializeField]
    private AudioSource displaySFX;

    public string fullText = "Display Text";
    private string currentText = "";
    public float timer = 0.0f;
    public int characterindex = 0;
    */

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
        if (textDisplay)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        /*
        buttonSFX.Stop();   
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            if (characterindex < fullText.Length)
            {
                characterindex++;
                //timer += 0.5f;
                DialogueText.text = fullText.Substring(0, characterindex);
                displaySFX.Play();
            }
            else
            {
                displaySFX.Stop();
            }

        }
       */
        

    }

    public void nextText()
    {
        DialogueID = DialogueID + 1;
        setText();
        buttonSFX.Play();
        /*
        characterindex = 0;
        timer = 0.0f;
        */
    }

    void setText()
    {
        
        if (dialogueDatabase.GetDialogue(DialogueID) != null)
        {
            if(string.Compare(dialogueDatabase.GetDialogue(DialogueID).text, "PAUSE") == 0)
            {
                DialoguePanel.SetActive(false);
                textDisplay = false;
            }
            else
            {
                DialoguePanel.SetActive(true);
                textDisplay = true;
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
            }
        }
        else
        {
            DialoguePanel.SetActive(false);
            textDisplay = false;
        }
        

    }

}
