using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePanelScript : MonoBehaviour
{
    [SerializeField]
    private GameObject DialoguePanel;
    [SerializeField]
    private AudioSource buttonSFX;

    private DialogueCollision dialogueCollision;

    [SerializeField]
    private List<GameObject> TutorialPanel;

    private int currentTutorialPanel = 0;

    [SerializeField]
    private Button ZoomOut;

    [SerializeField]
    private GameObject FairyTalk;

    [SerializeField]
    private GameObject rightArrow1;

    [SerializeField]
    private GameObject leftArrow1;

    public void setCurrentDialogueEvent(GameObject dialogueEvent)
    {
        this.dialogueCollision = dialogueEvent.GetComponent<DialogueCollision>();
        Time.timeScale = 0;
        ZoomOut.interactable = false;
    }

    public void CloseDialoguePanel()
    {
        if (this.dialogueCollision.getStartIndex() < this.dialogueCollision.getEndIndex())
        {
            this.dialogueCollision.NextText();
            this.dialogueCollision.setText();
            if(currentTutorialPanel < TutorialPanel.Count)
            {
                if (this.dialogueCollision.DisplayPage() != -1)
                {
                    this.currentTutorialPanel = this.dialogueCollision.DisplayPage();
                    TutorialPanel[this.currentTutorialPanel].SetActive(true);
                }
                else
                {
                    TutorialPanel[this.currentTutorialPanel].SetActive(false);
                }
            }
            if(this.dialogueCollision.displayArrow() != null)
            {
                if (this.dialogueCollision.displayArrow().Contains("Right1"))
                {
                    rightArrow1.SetActive(true);
                    leftArrow1.SetActive(false);
                }
                else if (this.dialogueCollision.displayArrow().Contains("Left1"))
                {
                    rightArrow1.SetActive(false);
                    leftArrow1.SetActive(true);
                }
            }
            else
            {
                rightArrow1.SetActive(false);
                leftArrow1.SetActive(false);
            }

        }
        else
        {
            if (this.dialogueCollision.DisplayPage() != -1)
            {
                TutorialPanel[this.currentTutorialPanel].SetActive(false);
            }
            this.dialogueCollision.DestroyObject();
            DialoguePanel.SetActive(false);
            Time.timeScale = 1;
            ZoomOut.interactable = true;
            FairyTalk.SetActive(false);
            rightArrow1.SetActive(false);
            leftArrow1.SetActive(false);
        }
        buttonSFX.Play();
    }

    public void SkipDialogue()
    {
        buttonSFX.Play();
        this.dialogueCollision.DestroyObject();
        DialoguePanel.SetActive(false);
        Time.timeScale = 1;
        ZoomOut.interactable = true;
        FairyTalk.SetActive(false);
        TutorialPanel[currentTutorialPanel].SetActive(false);
        rightArrow1.SetActive(false);
        leftArrow1.SetActive(false);
    }
}
