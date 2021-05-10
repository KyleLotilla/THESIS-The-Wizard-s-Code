using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStart : MonoBehaviour
{
    [SerializeField]
    private DialoguePanel dialoguePanel;
    [SerializeField]
    private int dialogueID;
    [SerializeField]
    private DialogueVisualPanel dialogueVisualPanel;

    // Start is called before the first frame update
    void Start()
    {
        if (dialogueVisualPanel != null)
        {
            dialogueVisualPanel.gameObject.SetActive(true);
        }
        dialoguePanel.ShowDialogue(dialogueID);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
