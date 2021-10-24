using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Tags;
using DLSU.WizardCode.Events;

namespace DLSU.WizardCode.Dialogues
{
    [Serializable]
    public class Dialogue
    {
        [SerializeField]
        private Tag tag;
        public Tag Tag
        {
            get
            {
                return tag;
            }
        }
        [SerializeField]
        private GameEvent onDialogueStartEvent;
        [SerializeField]
        private GameEvent onDialogueEndEvent;
        [SerializeField]
        private List<DialogueLine> lines;
        public IEnumerable<DialogueLine> Lines
        {
            get
            {
                return lines;
            }
        }

        public int LineCount
        {
            get
            {
                return lines.Count;
            }
        }

        public void RaiseDialogueStartEvent()
        {
            onDialogueStartEvent?.Raise();
        }

        public void RaiseDialogueEndEvent()
        {
            onDialogueEndEvent?.Raise();
        }
    }

}
