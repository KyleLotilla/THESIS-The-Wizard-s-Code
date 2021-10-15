using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Tags;
using DLSU.WizardCode.ScriptableObjectVariables;

namespace DLSU.WizardCode.Dialogues
{
    public class ReadDialogueOnStart : MonoBehaviour
    {
        [SerializeField]
        private Tag dialogueTag;
        [SerializeField]
        private DialogueReaderVariable dialogueReader;

        void Start()
        {
            dialogueReader.StartReadingDialogue(dialogueTag);
        }
    }

}

