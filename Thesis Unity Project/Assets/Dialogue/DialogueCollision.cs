using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueCollision : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private DialoguePanel dialoguePanel;
    [SerializeField]
    private DialogueVisualPanel dialogueVisualPanel;

    [SerializeField]
    private int dialogueID;
    [SerializeField]
    private FairyTalking fairyTalking;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Wizard")
        {
            WizardMovement wizardMovement = col.gameObject.GetComponent<WizardMovement>();
            if (wizardMovement != null)
            {
                wizardMovement.StopWalking();
            }
            spriteRenderer.enabled = false;
            fairyTalking.OnFairyTalkingEnd += OnFairyTalkingEnd;
            fairyTalking.StartTalking();
        }
    }

    private void OnFairyTalkingEnd()
    {
        dialoguePanel.OnDialogueEnd += OnDialogueEnd;
        dialoguePanel.ShowDialogue(dialogueID);
        if (dialogueVisualPanel != null)
        {
            dialogueVisualPanel.gameObject.SetActive(true);
        }
    }

    private void OnDialogueEnd()
    {
        dialoguePanel.OnDialogueEnd -= OnDialogueEnd;
        Destroy(this.gameObject);
    }
}

