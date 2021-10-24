using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DLSU.WizardCode.Dialogues
{
    public class SetReadDialogueLineTextToTextUI : MonoBehaviour
    {
        [SerializeField]
        private Text text;

        public void OnDialogueRead(DialogueLine dialogueLine)
        {
            text.text = dialogueLine.LineText;
        }
    }
}


