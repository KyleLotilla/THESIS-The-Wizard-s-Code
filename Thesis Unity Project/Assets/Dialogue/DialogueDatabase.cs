using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Linq;
using System.Xml.Linq;
using System.IO;

public class DialogueDatabase : MonoBehaviour
{
    [SerializeField]
    private XMLDocumentReader xmlDocumentReader;
    [SerializeField]
    private List<Dialogue> dialogues;

    private void Awake()
    {
        dialogues = new List<Dialogue>();
        LoadXml(xmlDocumentReader.ReadXMLDocument());
    }

    void LoadXml(XDocument document)
    {
        XElement root = document.Root;
        foreach (XElement element in root.Elements())
        {
            if (element.Elements("ID").Any())
            {
                Dialogue dialogue = new Dialogue();
                dialogue.id = int.Parse(element.Element("ID").Value);
                if (element.Elements("Lines").Any())
                {
                    XElement lines = element.Element("Lines");
                    foreach (XElement line in lines.Elements())
                    {
                        dialogue.AddLine(line.Value);
                    }
                }
                dialogues.Add(dialogue);
            }
        }
    }

    public Dialogue GetDialogue(int dialogueID)
    {
        if (dialogueID >= 0 && dialogueID < dialogues.Count)
        {
            return dialogues[dialogueID];
        }
        else
        {
            return null;
        }
    }


}
