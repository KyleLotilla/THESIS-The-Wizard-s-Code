using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class LevelDatabase : XMLDatabaseComponent, IEnumerable
{
    [SerializeField]
    private List<Level> levels;

    [SerializeField]
    private string pathToXMLDatabase;

    public IEnumerator GetEnumerator()
    {
        return ((IEnumerable)levels).GetEnumerator();
    }

    // Start is called before the first frame update
    private void Awake()
    {
        LoadXml(LoadLocalXmlDocument(pathToXMLDatabase));
    }

    void LoadXml(XDocument document)
    {
        levels = new List<Level>();
        XElement root = document.Root;
        foreach (XElement element in root.Elements())
        {
            Level level = new Level();
            if (element.Elements("LevelNum").Any())
            {
                level.levelNum = int.Parse(element.Element("LevelNum").Value);
            }
            if (element.Elements("WorldNum").Any())
            {
                level.worldNum = int.Parse(element.Element("WorldNum").Value);
            }
            if (element.Elements("LevelPath").Any())
            {
                level.pathToLevel = element.Element("LevelPath").Value;
            }
            if (element.Elements("LevelOverview").Any())
            {
                level.pathToLevelOverview = element.Element("LevelOverview").Value;
                level.levelOverview = Resources.Load<Sprite>(level.pathToLevelOverview);
            }

            level.materials = new List<int>();
            level.numMaterials = new List<int>();
            if (element.Elements("Materials").Any())
            {
                XElement materials = element.Element("Materials");
                foreach (XElement material in materials.Elements())
                {
                    if (material.Elements("ID").Any() && material.Elements("Num").Any())
                    {
                        level.materials.Add(int.Parse(material.Element("ID").Value));
                        level.numMaterials.Add(int.Parse(material.Element("Num").Value));
                    }
                }
            }

            level.obstacles = new List<int>();
            level.numObstacles = new List<int>();
            if (element.Elements("Obstacles").Any())
            {
                XElement obstacles = element.Element("Obstacles");
                foreach (XElement obstacle in obstacles.Elements())
                {
                    if (obstacle.Elements("ID").Any() && obstacle.Elements("Num").Any())
                    {
                        level.obstacles.Add(int.Parse(obstacle.Element("ID").Value));
                        level.numObstacles.Add(int.Parse(obstacle.Element("Num").Value));
                    }
                }
            }
            levels.Add(level);
        }
    }
}
