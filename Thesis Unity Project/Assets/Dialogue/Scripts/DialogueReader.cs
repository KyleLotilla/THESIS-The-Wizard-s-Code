using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Tags;
using DLSU.WizardCode.Events;

namespace DLSU.WizardCode.Dialogues
{
    public class DialogueReader : MonoBehaviour
    {
        [SerializeField]
        private DialogueDatabase dialogueDatabase;
        [SerializeField]
        private UnityEventOneDialogueParam onDialogueStart;
        [SerializeField]
        private UnityEventOneDialogueLineParam onDialogueLineRead;
        [SerializeField]
        private UnityEventOneDialogueParam onDialogueEnd;

        private IEnumerator<DialogueLine> currentDialogueLineEnumerator;
        private Dialogue currentDialogue;

        public void StartReadingDialogue(Tag dialogueTag)
        {
            currentDialogue = dialogueDatabase.GetDialogue(dialogueTag);
            if (currentDialogue != null)
            {
                currentDialogueLineEnumerator = currentDialogue.Lines.GetEnumerator();
                onDialogueStart?.Invoke(currentDialogue);
                currentDialogue.RaiseDialogueStartEvent();
                ReadNextDialogueLine();
            }
        }

        public void ReadNextDialogueLine()
        {
            if (currentDialogue != null && currentDialogueLineEnumerator != null)
            {
                if (currentDialogueLineEnumerator.MoveNext())
                {
                    DialogueLine currentDialogueLine = currentDialogueLineEnumerator.Current;
                    onDialogueLineRead?.Invoke(currentDialogueLine);
                    currentDialogueLine.RaiseDialogeReadEvent();
                }
                else
                {
                    EndReadingDialogue();
                }
            }
        }

        public void EndReadingDialogue()
        {
            if (currentDialogue != null && currentDialogueLineEnumerator != null)
            {
                onDialogueEnd?.Invoke(currentDialogue);
                currentDialogue.RaiseDialogueEndEvent();
                currentDialogueLineEnumerator = null;
                currentDialogue = null;
            }
        }
    }
}


