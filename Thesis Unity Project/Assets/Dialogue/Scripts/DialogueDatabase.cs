using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Tags;

namespace DLSU.WizardCode.Dialogues
{
    [CreateAssetMenu(menuName = "Dialogue/DialogueDatabase")]
    public class DialogueDatabase : ScriptableObject
    {
        [SerializeField]
        private List<Dialogue> dialogues;

        private Dictionary<Tag, Dialogue> tagDialogueMap;

        private void OnEnable()
        {
            tagDialogueMap = new Dictionary<Tag, Dialogue>();
            foreach (Dialogue dialogue in dialogues)
            {
                tagDialogueMap[dialogue.Tag] = dialogue;
            }
        }

        public Dialogue GetDialogue(Tag dialogueTag)
        {
            Debug.Assert(tagDialogueMap.ContainsKey(dialogueTag), name + ": Dialogue Tag \"" + dialogueTag.TagName + "\" not found");
            if (tagDialogueMap.ContainsKey(dialogueTag))
            {
                return tagDialogueMap[dialogueTag];
            }
            else
            {
                return null;
            }
        }
    }

}
