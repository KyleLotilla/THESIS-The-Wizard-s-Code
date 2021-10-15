using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void OnDialogueLineChanged(int currentLine);
public delegate void OnDialogueEnd();

public class DialoguePanel : MonoBehaviour
{
    /*
    public event OnDialogueLineChanged OnDialogueLineChanged;
    public event OnDialogueEnd OnDialogueEnd;

    [SerializeField]
    private DialogueDatabase dialogueDatabase;
    [SerializeField]
    private Text text;

    private Dialogue currentDialogue;
    private int currentLine = 0;

    public void ShowDialogue(int diagloueID)
    {
        currentDialogue = dialogueDatabase.GetDialogue(diagloueID);
        if (currentDialogue != null)
        {
            currentLine = 0;
            text.text = currentDialogue.GetLine(0);
            this.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void NextLine()
    {
        currentLine++;
        if (currentLine < currentDialogue.lineCount)
        {
            Debug.Log(currentDialogue.GetLine(currentLine));
            text.text = currentDialogue.GetLine(currentLine);
            OnDialogueLineChanged?.Invoke(currentLine);
        }
        else
        {
            EndDialogue();
        }
    }

    public void EndDialogue()
    {
        OnDialogueEnd?.Invoke();
        /*
        OnDialogueLineChanged = null;
        OnDialogueEnd = null;
        
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }
    */
}
