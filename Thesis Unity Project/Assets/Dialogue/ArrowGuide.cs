using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGuide : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private Image Arrows;

    [SerializeField]
    private GameObject ArrowPrefab;

    [SerializeField]
    private DialoguePanel dialoguePanel;

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
        DisplayArrow();
    }

    public void DisplayArrow()
    {
        this.Arrows.enabled = true;
    }

    public void SetArrowActive()
    {
        this.ArrowPrefab.SetActive(true);
    }

    public void HideArrow()
    {
        this.ArrowPrefab.SetActive(false);
        this.Arrows.enabled = false;

    }
}
