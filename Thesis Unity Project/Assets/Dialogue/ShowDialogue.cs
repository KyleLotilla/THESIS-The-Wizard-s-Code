using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDialogue : MonoBehaviour
{
    [SerializeField]
    private int dialogueID;
    [SerializeField]
    private DialoguePanel dialoguePanel;
    [SerializeField]
    private DialogueVisualPanel dialogueVisualPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show()
    {
        dialoguePanel.ShowDialogue(dialogueID);
        if (dialogueVisualPanel != null)
        {
            dialogueVisualPanel.gameObject.SetActive(true);
        }
    }
}
