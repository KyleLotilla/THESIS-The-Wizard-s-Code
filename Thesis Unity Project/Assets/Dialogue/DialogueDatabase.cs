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

    [SerializeField]
    private string pathToXMLDatabase;

    // Start is called before the first frame update
    void OnEnable()
    {
        if (dialogues != null)
        {
            dialogues.Clear();
        }
        else
        {
            dialogues = new Dictionary<int, Dialogue>();
        }

        LoadXml(LoadLocalXmlDocument(pathToXMLDatabase));
    }


    void LoadXml(XDocument document)
    {
        XElement root = document.Root;
        foreach (XElement element in root.Elements())
        {
            if (element.Elements("ID").Any())
            {
                Dialogue dialogue = new Dialogue();
                dialogue.DialogueID = int.Parse(element.Element("ID").Value);

                if (element.Elements("Text").Any())
                {
                    dialogue.text = element.Element("Text").Value;
                }
                dialogues.Add(dialogue.DialogueID, dialogue);
            }
        }
    }

    public Dialogue GetDialogue(int id)
    {
        if (dialogues.ContainsKey(id))
        {
            Dialogue dialogue = dialogues[id];
            Dialogue Copydialogue = new Dialogue();
            Copydialogue.DialogueID = dialogue.DialogueID;
            Copydialogue.text = dialogue.text;
            return Copydialogue;
        }
        else
        {
            return null;
        }
    }


}
