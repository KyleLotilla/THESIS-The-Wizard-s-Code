using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueCollision : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject DialoguePanel;
    [SerializeField]
    private Text DialogueText;
    
    [SerializeField]
    private DialogueDatabase dialogueDatabase;

    [SerializeField]
    private string pathToXMLDatabase;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        dialogueDatabase.setPath(pathToXMLDatabase);
        
        if (col.gameObject.tag == "Wizard")
        {
            if(dialogueDatabase.GetDialogue() != null)
            {
                DialoguePanel.SetActive(true);
                //Debug.Log(dialogueDatabase.GetDialogue().text);
                DialogueText.text = dialogueDatabase.GetDialogue().text;
                Time.timeScale = 0;
            }
            Destroy(this.gameObject);
        }
    }
}

