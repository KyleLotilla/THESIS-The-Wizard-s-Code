using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Linq;
using System.Xml.Linq;
using System.IO;

[CreateAssetMenu(menuName = "Database/Material Database")]
public class MaterialDatabase : XMLDatabaseScriptableObject
{
    [SerializeField]
    private Dictionary<int, Material> materials;
    [SerializeField]
    private XMLDocumentReader xmlDocumentReader;

    void OnEnable()
    {
        if (materials != null)
        {
            materials.Clear();
        }
        else
        {
            materials = new Dictionary<int, Material>();
        }

        LoadXml(xmlDocumentReader.ReadXMLDocument());
    }

    void LoadXml(XDocument document)
    {
        XElement root = document.Root;
        foreach(XElement element in root.Elements())
        {
            if(element.Elements("ID").Any())
            {
                Material material = new Material();
                material.materialID = int.Parse(element.Element("ID").Value);

                if (element.Elements("Name").Any())
                {
                    material.name = element.Element("Name").Value;
                }

                if (element.Elements("Description").Any())
                {
                    material.description = element.Element("Description").Value;
                }

                if (element.Elements("Icon").Any())
                {
                    material.iconPath = element.Element("Icon").Value;
                    material.icon = Resources.Load<Sprite>(material.iconPath);
                }

                materials.Add(material.materialID, material);
            }
        }
    }

    public Material GetMaterial(int id)
    {
        if (materials.ContainsKey(id))
        {
            Material material = materials[id];
            Material materialCopy = new Material();
            materialCopy.materialID = material.materialID;
            materialCopy.name = material.name;
            materialCopy.description = material.description;
            materialCopy.icon = material.icon;
            materialCopy.iconPath = material.iconPath;
            return materialCopy;
        }
        else
        {
            return null;
        }
    }
}
