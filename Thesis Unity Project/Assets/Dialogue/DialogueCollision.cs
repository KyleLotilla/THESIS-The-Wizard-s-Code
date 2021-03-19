using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueCollision : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    public int DialogueID;
    [SerializeField]
    private GameObject DialoguePanel;
    [SerializeField]
    private Text DialogueText;
    
    [SerializeField]
    private DialogueDatabase dialogueDatabase;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wizard")
        {
            if(dialogueDatabase.GetDialogue(DialogueID) != null)
            {
                DialoguePanel.SetActive(true);
                Debug.Log(dialogueDatabase.GetDialogue(DialogueID).text);
                DialogueText.text = dialogueDatabase.GetDialogue(DialogueID).text;
                Time.timeScale = 0;
            }
            Destroy(this.gameObject);
        }
    }
}

