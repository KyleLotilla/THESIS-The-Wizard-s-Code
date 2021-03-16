using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCollision : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    public int DialogueID;

    
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
                Debug.Log(dialogueDatabase.GetDialogue(DialogueID).text);
            }
            Destroy(this.gameObject);
        }
    }
}

