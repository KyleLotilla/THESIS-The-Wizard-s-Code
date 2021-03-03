using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Database/Level Database")]
public class LevelDatabase : XMLDatabase
{
    [SerializeField]
    private Dictionary<int, Level> levels;

    [SerializeField]
    private string pathToXMLDatabase;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void LoadXml(XDocument document)
    {
        XElement root = document.Root;
        foreach (XElement element in root.Elements())
        {
            if (element.Elements("ID").Any())
            {
                Level level = new Level();
                level.id = int.Parse(element.Element("ID").Value);

                if (element.Elements("PathToLevelScene").Any())
                {
                    level.PathToLevelScene = element.Element("PathToLevelScene").Value;
                }


            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
