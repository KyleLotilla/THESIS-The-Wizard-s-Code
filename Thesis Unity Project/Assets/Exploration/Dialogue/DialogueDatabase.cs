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
    private string text = null;

    private string pathToXMLDatabase = null;

    // Start is called before the first frame update
    void OnEnable()
    {
        
    }


    void LoadXml(XDocument document)
    {
        XElement root = document.Root;
        foreach (XElement element in root.Elements())
        {
            if (element.Elements("Text").Any())
            {
                this.text = element.Element("Text").Value;
            }
                
        }
    }

    public void setPath(string path)
    {
        pathToXMLDatabase = path;
        LoadXml(LoadLocalXmlDocument(pathToXMLDatabase));
    }

    public Dialogue GetDialogue()
    {
        if(this.text != null)
        {
            Dialogue Copydialogue = new Dialogue();
            Copydialogue.text = this.text;
            return Copydialogue;
        }
        
        else
        {
            return null;
        }
    }


}
