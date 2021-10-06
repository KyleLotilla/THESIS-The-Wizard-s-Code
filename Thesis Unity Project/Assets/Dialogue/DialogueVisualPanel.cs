using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueVisualPanel : MonoBehaviour
{
    [SerializeField]
    private DialoguePanel dialoguePanel;
    /*
    [SerializeField]
    private TabsPanel tabsPanel;
    */
    [SerializeField]
    private List<DialogueLinePagePair> dialogueLinePagePairs;
    private Dictionary<int, int> dialogueLinePageMapping;
    [SerializeField]
    private int defaultVisual = -1;
    // Start is called before the first frame update
    void Start()
    {
        dialogueLinePageMapping = new Dictionary<int, int>();
        if (dialogueLinePagePairs != null)
        {
            foreach (DialogueLinePagePair pair in dialogueLinePagePairs)
            {
                dialogueLinePageMapping[pair.lineNum] = pair.visualPage;
            }
        }
        dialoguePanel.OnDialogueLineChanged += OnDialogueLineChanged;
        dialoguePanel.OnDialogueEnd += OnDialogueEnd;
    }

    private void OnDialogueEnd()
    {
        dialoguePanel.OnDialogueLineChanged -= OnDialogueLineChanged;
        dialoguePanel.OnDialogueEnd -= OnDialogueEnd;
        this.gameObject.SetActive(false);
    }

    private void OnDialogueLineChanged(int currentLine)
    {
        /*
        if (dialogueLinePageMapping.ContainsKey(currentLine))
        {
            tabsPanel.SwitchPage(dialogueLinePageMapping[currentLine]);
        }
        else
        {
            tabsPanel.SwitchPage(defaultVisual);
        }
        */
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
