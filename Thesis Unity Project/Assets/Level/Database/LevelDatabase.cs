using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "LevelDatabase")]
public class LevelDatabase : ScriptableObject, IEnumerable<Level>
{
    [SerializeField]
    private Dictionary<int, int> levelIndices;

    [SerializeField]
    private List<Level> levels;

    [SerializeField]
    private XMLDocumentReader xmlDocumentReader;

    public IEnumerator GetEnumerator()
    {
        return ((IEnumerable)levels).GetEnumerator();
    }

    // Start is called before the first frame update
    private void OnEnable()
    {
        LoadXml(xmlDocumentReader.ReadXMLDocument());
    }

    void LoadXml(XDocument document)
    {
        levels = new List<Level>();
        levelIndices = new Dictionary<int, int>();
        XElement root = document.Root;
        foreach (XElement element in root.Elements())
        {
            Level level = new Level();
            if (element.Elements("ID").Any())
            {
                level.levelID = int.Parse(element.Element("ID").Value);
            }

            if (element.Elements("LevelNum").Any())
            {
                level.levelNum = int.Parse(element.Element("LevelNum").Value);
            }
            if (element.Elements("WorldNum").Any())
            {
                level.worldNum = int.Parse(element.Element("WorldNum").Value);
            }
            if (element.Elements("SceneIndex").Any())
            {
                level.sceneIndex = int.Parse(element.Element("SceneIndex").Value);
            }
            if (element.Elements("LevelOverview").Any())
            {
                level.pathToLevelOverview = element.Element("LevelOverview").Value;
                level.levelOverview = Resources.Load<Sprite>(level.pathToLevelOverview);
            }

            level.obstacleLevelInfos = new List<ObstacleLevelInfo>();
            if (element.Elements("Obstacles").Any())
            {
                XElement obstacles = element.Element("Obstacles");
                foreach (XElement obstacle in obstacles.Elements())
                {
                    if (obstacle.Elements("ID").Any() && obstacle.Elements("Num").Any())
                    {
                        ObstacleLevelInfo obstacleLevelInfo = new ObstacleLevelInfo();
                        obstacleLevelInfo.obstacleID = int.Parse(obstacle.Element("ID").Value);
                        obstacleLevelInfo.numObstacles = int.Parse(obstacle.Element("Num").Value);
                        level.obstacleLevelInfos.Add(obstacleLevelInfo);
                    }
                }
            }

            level.unlockableSpellsIDs = new List<int>();

            if (element.Elements("UnlockableSpells").Any())
            {
                XElement spellIDs = element.Element("UnlockableSpells");
                foreach (XElement spellID in spellIDs.Elements())
                {
                    level.unlockableSpellsIDs.Add(int.Parse(spellID.Value));
                }
            }

            if (element.Elements("MaximumScore").Any())
            {
                level.maximumScore = int.Parse(element.Element("MaximumScore").Value);
            }

            if (element.Elements("StarUnlockRequirement").Any())
            {
                level.starUnlockRequirement = int.Parse(element.Element("StarUnlockRequirement").Value);
            }

            if (element.Elements("TwoStarRequirement").Any())
            {
                level.twoStarRequirement = int.Parse(element.Element("TwoStarRequirement").Value);
            }

            if (element.Elements("ThreeStarRequirement").Any())
            {
                level.threeStarRequirement = int.Parse(element.Element("ThreeStarRequirement").Value);
            }
      

            levels.Add(level);
            levelIndices[level.levelID] = levels.Count - 1;
        }
    }

    public Level GetLevel(int levelID)
    {
        if (levelIndices.ContainsKey(levelID))
        {
            return levels[levelIndices[levelID]];
        }
        else
        {
            return null;
        }
    }

    IEnumerator<Level> IEnumerable<Level>.GetEnumerator()
    {
        return ((IEnumerable<Level>)levels).GetEnumerator();
    }
}
