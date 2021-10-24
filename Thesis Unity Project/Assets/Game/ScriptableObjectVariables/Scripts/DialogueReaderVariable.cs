using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Dialogues;
using DLSU.WizardCode.Tags;

namespace DLSU.WizardCode.ScriptableObjectVariables
{
    [CreateAssetMenu(menuName = "Dialogue/DialogueReaderVariable")]
    public class DialogueReaderVariable : ScriptableObject
    {
        [SerializeField]
        private DialogueReader currentValue;
        public DialogueReader Value
        {
            get
            {
                return currentValue;
            }
            set
            {
                currentValue = value;
            }
        }

        private void OnEnable()
        {
            currentValue = null;
        }

        public void StartReadingDialogue(Tag dialogueTag)
        {
            currentValue.StartReadingDialogue(dialogueTag);
        }
    }
}
