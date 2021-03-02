using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;
using System.IO;
using System.Linq;

public class XMLDatabase : ScriptableObject
{
    protected XDocument LoadLocalXmlDocument(string pathToXMLDatabase)
    {
        FileStream stream = new FileStream(pathToXMLDatabase, FileMode.Open, FileAccess.Read);
        XDocument document = XDocument.Load(stream);
        stream.Close();

        return document;
    }
}
