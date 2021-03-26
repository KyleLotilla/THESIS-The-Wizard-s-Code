using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Linq;
using System.Xml.Linq;
using System.IO;


[CreateAssetMenu(menuName = "Database/Dialogue Database")]
public class DialogueDatabase : XMLDatabaseScriptableObject
{
    [SerializeField]
    private Dictionary<int, Dialogue> dialogues;

    private string pathToXMLDatabase;

    // Start is called before the first frame update
    void OnEnable()
    {
        if(dialogues != null)
        {
            dialogues.Clear();
        }
        else
        {
            dialogues = new Dictionary<int, Dialogue>();
        }
    }


    void LoadXml(XDocument document)
    {
        XElement root = document.Root;
        foreach (XElement element in root.Elements())
        {
            if (element.Elements("ID").Any())
            {
                Dialogue dialogue = new Dialogue();
                dialogue.ID = int.Parse(element.Element("ID").Value);

                if (element.Elements("Text").Any())
                {
                    dialogue.text = element.Element("Text").Value;
                }
                if (element.Elements("Bold").Any())
                {
                    dialogue.bold = element.Element("Bold").Value;
                }
                dialogues.Add(dialogue.ID, dialogue);
            }
                
        }
    }

    public void setPath(string path)
    {
        pathToXMLDatabase = path;
        LoadXml(LoadLocalXmlDocument(pathToXMLDatabase));
    }

    public Dialogue GetDialogue(int DialogueID)
    {
        if (dialogues.ContainsKey(DialogueID))
        {
            Dialogue dialogue = dialogues[DialogueID];
            Dialogue copydialogue = new Dialogue();
            copydialogue.text = dialogue.text;
            if(dialogue.bold != null)
            {
                copydialogue.bold = dialogue.bold;
            }
            
            return copydialogue;
        }
        else
        {
            return null;
        }
    }


}
