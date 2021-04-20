using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePanelScript : MonoBehaviour
{
    [SerializeField]
    private GameObject DialoguePanel;
    [SerializeField]
    private AudioSource buttonSFX;

    private DialogueCollision dialogueCollision;

    public void setCurrentDialogueEvent(GameObject dialogueEvent)
    {
        this.dialogueCollision = dialogueEvent.GetComponent<DialogueCollision>();
        Time.timeScale = 0;
    }

    public void CloseDialoguePanel()
    {

        if(this.dialogueCollision.getStartIndex() < this.dialogueCollision.getEndIndex())
        {
            this.dialogueCollision.NextText();
            this.dialogueCollision.setText();
        }
        else
        {
            this.dialogueCollision.DestroyObject();
            DialoguePanel.SetActive(false);
            Time.timeScale = 1;
        }
        buttonSFX.Play();
    }
}
