using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;
using System.IO;

public class XMLDatabaseComponent : MonoBehaviour
{
    protected XDocument LoadLocalXmlDocument(string pathToXMLDatabase)
    {
        //FileStream stream = new FileStream(pathToXMLDatabase, FileMode.Open, FileAccess.Read);
        TextAsset xml = Resources.Load<TextAsset>(pathToXMLDatabase);
        MemoryStream stream = new MemoryStream(xml.bytes);
        XDocument document = XDocument.Load(stream);
        stream.Close();

        return document;
    }
}
