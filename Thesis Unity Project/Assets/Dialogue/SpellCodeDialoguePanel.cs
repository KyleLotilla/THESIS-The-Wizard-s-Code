using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SpellCodeDialoguePanel : MonoBehaviour
{
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

    [SerializeField]
    private List<GameObject> UpArrows;

    [SerializeField]
    private List<GameObject> LeftArrows;

    

    // Start is called before the first frame update
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

    void setButtonsActive()
    {
        okButton.interactable = true;
    }

    void removeArrows()
    {
        for (int i = 0; i < UpArrows.Count; i++)
        {
            UpArrows[i].SetActive(false);
        }

        for(int i = 0; i < LeftArrows.Count; i++)
        {
            LeftArrows[i].SetActive(false);
        }

    }

    void setArrow()
    {
        if(string.Compare(dialogueDatabase.GetDialogue(DialogueID).Arrow, "Up1") == 0)
        {
            UpArrows[0].SetActive(true);
            okButton.interactable = false;
        }
        else if(string.Compare(dialogueDatabase.GetDialogue(DialogueID).Arrow, "Up2") == 0)
        {
            UpArrows[1].SetActive(true);
        }
        else if(string.Compare(dialogueDatabase.GetDialogue(DialogueID).Arrow, "Up4") == 0)
        {
            UpArrows[1].SetActive(false);
            UpArrows[3].SetActive(true);
        }
        else if(string.Compare(dialogueDatabase.GetDialogue(DialogueID).Arrow, "Left1") == 0)
        {
            LeftArrows[0].SetActive(true);
            okButton.interactable = false;
        }
        else
        {
            setButtonsActive();
            removeArrows();   
        }
    }

    public void nextText()
    {
        DialogueID = DialogueID + 1;
        setText();
        buttonSFX.Play();
    }

    public bool pausescript()
    {
        if(string.Compare(dialogueDatabase.GetDialogue(DialogueID).text, "PAUSEFORSPELLCODENAME") == 0)
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
        if (dialogueDatabase.GetDialogue(DialogueID) != null)
        {
            if(pausescript())
            {
                DialoguePanel.SetActive(false);
            }
            else
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

                setArrow();
            }
            
        }
        else
        {
            removeArrows();
            DialoguePanel.SetActive(false);
        }
    }
}
