using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneOnDialogueEnd : MonoBehaviour
{
    [SerializeField]
    private DialoguePanel dialoguePanel;
    [SerializeField]
    private LoadScene loadScene;

    // Start is called before the first frame update
    void Start()
    {
        dialoguePanel.OnDialogueEnd += OnDialogueEnd;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDialogueEnd()
    {
        loadScene.Load();
    }
}
