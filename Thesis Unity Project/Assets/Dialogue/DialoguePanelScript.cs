using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePanelScript : MonoBehaviour
{
    [SerializeField]
    private GameObject DialoguePanel;
    [SerializeField]
    private AudioSource buttonSFX;

    public void CloseDialoguePanel()
    {
        Time.timeScale = 1;
        DialoguePanel.SetActive(false);
        buttonSFX.Play();
    }
}
