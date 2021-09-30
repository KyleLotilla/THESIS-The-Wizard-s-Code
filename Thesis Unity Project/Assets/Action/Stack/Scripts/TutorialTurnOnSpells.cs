using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTurnOnSpells : MonoBehaviour
{
    /*
    [SerializeField]
    private ActionStack actionStack;
    */
    [SerializeField]
    private DialoguePanel dialoguePanel;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wizard")
        {
            dialoguePanel.OnDialogueEnd += OnDialogueEnd;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnDialogueEnd()
    {
        dialoguePanel.OnDialogueEnd -= OnDialogueEnd;
        /*
        actionStack.isTutorialMovementOnly = false;
        actionStack.SpawnSpellAction(0);
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
