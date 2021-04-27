﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePanelScript : MonoBehaviour
{
    [SerializeField]
    private GameObject DialoguePanel;
    [SerializeField]
    private AudioSource buttonSFX;

    private DialogueCollision dialogueCollision;

    [SerializeField]
    private List<GameObject> TutorialPanel;

    [SerializeField]
    private int currentTutorialPanel;

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
            if(currentTutorialPanel < TutorialPanel.Count)
            {
                if (this.dialogueCollision.DisplayImage())
                {
                    TutorialPanel[currentTutorialPanel].SetActive(true);
                }
                else
                {
                    TutorialPanel[currentTutorialPanel].SetActive(false);
                }
            }
        }
        else
        {
            if (this.dialogueCollision.DisplayImage())
            {
                TutorialPanel[currentTutorialPanel].SetActive(false);
                currentTutorialPanel = currentTutorialPanel + 1;
            }
            this.dialogueCollision.DestroyObject();
            DialoguePanel.SetActive(false);
            Time.timeScale = 1;
        }
        buttonSFX.Play();
    }

    public void SkipDialogue()
    {
        this.dialogueCollision.DestroyObject();
        DialoguePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
