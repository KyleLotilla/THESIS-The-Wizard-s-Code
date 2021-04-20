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
                if (element.Elements("Image").Any())
                {
                    dialogue.imagepath = element.Element("Image").Value;
                    dialogue.image = Resources.Load<Sprite>(dialogue.imagepath);
                }
                if (element.Elements("Bold").Any())
                {
                    dialogue.bold = element.Element("Bold").Value;
                }
                dialogues.Add(dialogue.ID, dialogue);
            }
                
        }
    }

    public string setBold(string bold, string text)
    {
        if(text.Contains(bold) != null)
        {
            text = text.Replace(bold, "<b>" + bold + "</b>");
            return text;
        }
        else
        {
            return null;
        }
    }

    public string setFairyName(string fairy, string text)
    {
        if(text.Contains("Fairie") != null)
        {
            text.Replace("Fairie", fairy);
            return text;
        }
        else
        {
            return null;
        }
    }

    public string setPlayerName(string player, string text)
    {
        if(text.Contains("Player") != null)
        {
            text = text.Replace("Player", player);
            return text;
        }
        else
        {
            return null;
        }
    }

    public void setPath(string path)
    {
        if (dialogues != null)
        {
            dialogues.Clear();
        }
        else
        {
            dialogues = new Dictionary<int, Dialogue>();
        }
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
            if(dialogue.imagepath != null)
            {
                copydialogue.imagepath = dialogue.imagepath;
                copydialogue.image = dialogue.image;
            }
            
            return copydialogue;
        }
        else
        {
            return null;
        }
    }


}
