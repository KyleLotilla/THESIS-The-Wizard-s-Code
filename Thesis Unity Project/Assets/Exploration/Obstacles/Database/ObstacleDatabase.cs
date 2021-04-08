using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

public class ObstacleDatabase : XMLDatabaseComponent
{
    private Dictionary<int, Obstacle> obstacles;
    [SerializeField]
    private string pathToXMLDatabase;
    // Start is called before the first frame update
    void Awake()
    {
        if (obstacles == null)
        {
            obstacles = new Dictionary<int, Obstacle>();
            LoadXml(LoadLocalXmlDocument(pathToXMLDatabase));
        }
    }

    void LoadXml(XDocument document)
    {
        XElement root = document.Root;
        foreach (XElement element in root.Elements())
        {
            if (element.Elements("ID").Any())
            {
                Obstacle obstacle = new Obstacle();
                obstacle.obstacleID = int.Parse(element.Element("ID").Value);

                if (element.Elements("Name").Any())
                {
                    obstacle.name = element.Element("Name").Value;
                }

                if (element.Elements("Icon").Any())
                {
                    obstacle.iconPath = element.Element("Icon").Value;
                    obstacle.icon = Resources.Load<Sprite>(obstacle.iconPath);
                }

                obstacles.Add(obstacle.obstacleID, obstacle);
            }
        }
    }

    public Obstacle GetObstacle(int id)
    {
        if (obstacles.ContainsKey(id))
        {
            Obstacle obstacle = obstacles[id];
            Obstacle obstacleCopy = new Obstacle();
            obstacleCopy.obstacleID = obstacle.obstacleID;
            obstacleCopy.name = obstacle.name;
            obstacleCopy.icon = obstacle.icon;
            obstacleCopy.iconPath = obstacle.iconPath;
            return obstacleCopy;
        }
        else
        {
            return null;
        }
    }
}
