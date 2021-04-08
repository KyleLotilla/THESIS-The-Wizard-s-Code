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

    [SerializeField]
    private AudioSource displaySFX;

    public string fullText = "Display Text";
    private string currentText = "";
    public float timer = 0.0f;
    public int characterindex = 0;

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
       
        

    }

    public void nextText()
    {
        DialogueID = DialogueID + 1;
        setText();
        characterindex = 0;
        timer = 0.0f;
    }

    public void untilCraft()
    {
        displaySFX.Stop();
        if (DialogueID < 1 || DialogueID > 1 && DialogueID < 5)
        {
            nextText();
        }
        else if (DialogueID >= 5)
        {
            //SceneManager.LoadScene(1);
            DialoguePanel.SetActive(false);
        }
        else
        {
            DialoguePanel.SetActive(false);
        }
        buttonSFX.Play();
    


    }

    public void Aftercraft()
    {
        displaySFX.Stop();
        DialoguePanel.SetActive(true);
        nextText();
        buttonSFX.Play();
    }

    IEnumerator ShowText()
    {

        for (int i = 0; i < fullText.ToCharArray().Length; i++){
            DialogueText.text += fullText.ToCharArray()[i]; 
        }
        yield return new WaitForSeconds(1f);
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
                     fullText = dialogueDatabase.setBold(test, dialogueDatabase.GetDialogue(DialogueID).text);
                }
            }
            else
            {

                fullText = dialogueDatabase.GetDialogue(DialogueID).text;
                
            }
            Time.timeScale = 0;
            

        }
        else
        {
            DialoguePanel.SetActive(false);
        }
        
    }

}
