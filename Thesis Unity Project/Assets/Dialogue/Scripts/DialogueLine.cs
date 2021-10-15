using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Events;

namespace DLSU.WizardCode.Dialogues
{
    [Serializable]
    public class DialogueLine
    {
        [SerializeField]
        private GameEvent onDialogueReadEvent;
        [TextArea(3, 10)]
        [SerializeField]
        private string lineText;
        public string LineText
        {
            get
            {
                return lineText;
            }
        }

        public void RaiseDialogeReadEvent()
        {
            onDialogueReadEvent?.Raise();
        }
    }

}
