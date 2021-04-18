using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;
using System.IO;

[Serializable]
public class XMLDocumentReader
{
    [SerializeField]
    private TextAsset xmlTextAsset;

    public XDocument ReadXMLDocument()
    {
        MemoryStream stream = new MemoryStream(xmlTextAsset.bytes);
        XDocument document = XDocument.Load(stream);
        stream.Close();
        return document;
    }

    public XDocument ReadXMLDocument(string xmlPath)
    {
        if (Directory.Exists(Path.GetDirectoryName(xmlPath)))
        {
            if (File.Exists(xmlPath))
            {
                FileStream stream = new FileStream(xmlPath, FileMode.Open, FileAccess.Read);
                XDocument document = XDocument.Load(stream);
                stream.Close();
                return document;
            }
        }
        return null;
    }

    
}
