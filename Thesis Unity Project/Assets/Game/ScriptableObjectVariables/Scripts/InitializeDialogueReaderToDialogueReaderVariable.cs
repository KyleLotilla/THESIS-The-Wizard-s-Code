using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Dialogues;

namespace DLSU.WizardCode.ScriptableObjectVariables
{
    public class InitializeDialogueReaderToDialogueReaderVariable : MonoBehaviour
    {
        [SerializeField]
        private DialogueReader dialogueReader;
        [SerializeField]
        private DialogueReaderVariable dialogueReaderVariable;

        private void Start()
        {
            dialogueReaderVariable.Value = dialogueReader;
        }
    }
}

